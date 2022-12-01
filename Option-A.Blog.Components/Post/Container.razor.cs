using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Icon;

namespace OptionA.Blog.Components.Post
{
    public partial class Container
    {
        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public IPostContent? ContainerContent { get; set; }

        private BlockContent? Content => GetContent();
        private bool _closed;        

        private void SwitchStatus()
        {
            _closed = !_closed;
            StateHasChanged();
        }

        private BlockContent? GetContent()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return null;
            }

            var builder = ComponentBuilder
                .CreateBuilder()
                    .CreateBlock()
                        .AddClasses(DefaultClasses.Container);

            if (_closed)
            {
                builder.WithAttribute("closed");
            }

            builder
                .CreateBlock()
                    .AddClasses(DefaultClasses.ContainerHeader)
                    .CreateBlock()
                        .WithText(Name)
                        .AddClasses(DefaultClasses.ContainerHeaderName)
                        .Build()
                    .CreateBlock()
                        .AddIcon(_closed ? "bi bi-chevron-down" : "bi bi-chevron-up")
                        .AddMargin(Side.Left, Strength.Auto)
                        .AddClasses(DefaultClasses.ContainerHideButton)
                        .WithOnClick((e) =>
                        {
                            SwitchStatus();
                            return Task.CompletedTask;
                        })
                        .Build()
                    .Build();

            if (!_closed && ContainerContent is not null)
            {
                var content = builder
                    .CreateBlock()
                        .AddClasses(DefaultClasses.ContainerContent);
                content.AddContent(ContainerContent);
                content
                    .Build();
            }
                        
            return builder
                    .Build()
                .BuildOne<BlockContent>();

        }
    }
}
