using Azure;
using Azure.Storage.Blobs;
using OptionA.Blazor.Blog;
using OptionA.Blazor.Blog.Services;
using OptionA.Blazor.Components;

namespace Blog.Client
{
    public class PostClient(IBuilderService builderService, IMessageService messageService) : IPostClient
    {
        private readonly IBuilderService _builderService = builderService;
        private readonly IMessageService _messageService = messageService;

        private const string Url = "https://optiona.blob.core.windows.net";
        private BlobServiceClient? _client;

        public async Task<List<string>> List(string container, string folder, Func<string, bool>? filter, CancellationToken cancellationToken)
        {
            var client = GetClient()
                .GetBlobContainerClient(container.ToLowerInvariant());

            var result = new List<string>();

            try
            {
                var blobs = client.GetBlobsAsync(prefix: folder.ToLowerInvariant(), cancellationToken: cancellationToken);


                await foreach (var blobItem in blobs)
                {
                    if (filter == null || filter(blobItem.Name))
                    {
                        result.Add(blobItem.Name[(folder.Length + 1)..].Replace(".json", string.Empty));
                    }
                }
            }
            catch (RequestFailedException e)
            {
                _messageService.AddMessage(new()
                {
                    Content = $"{e.ErrorCode}: {e.Message}",
                    Dismissable = true,
                    Title = $"List Error ({container})",
                    Type = MessageType.Error
                });
            }
            catch (Exception e)
            {
                _messageService.AddMessage(new()
                {
                    Content = $"{e.Message}",
                    Dismissable = true,
                    Title = $"Error during getting posts",
                    Type = MessageType.Error
                });
            }

            return result;
        }

        public async Task<List<string>> List(string container, string folder, CancellationToken cancellationToken)
        {
            return await List(container, folder, null, cancellationToken);
        }

        public async Task<Post?> Load(string postId, string container, string folder, CancellationToken cancellationToken)
        {
            var client = GetClient()
                .GetBlobContainerClient(container.ToLowerInvariant())
                .GetBlobClient($"{folder}/{postId}.json");

            string json;
            try
            {
                var blob = await client.DownloadContentAsync(cancellationToken);
                json = blob.Value.Content.ToString();
            }
            catch (RequestFailedException e)
            {
                _messageService.AddMessage(new()
                {
                    Content = $"{e.ErrorCode}: {e.Message}",
                    Dismissable = true,
                    Title = "Load Error",
                    Type = MessageType.Error
                });
                return null;
            }

            try
            {
                return _builderService.CreateFromJson(json);
            }
            catch (InvalidCastException e)
            {
                _messageService.AddMessage(new()
                {
                    Content = e.Message,
                    Dismissable = true,
                    Title = "Load Error",
                    Type = MessageType.Error
                });
                return null;
            }
        }

        private BlobServiceClient GetClient()
        {
            return _client ??= new BlobServiceClient(new Uri(Url));
        }
    }
}
