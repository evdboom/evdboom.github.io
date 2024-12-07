using Microsoft.AspNetCore.Components;

namespace Blog.Shared
{
    public partial class ConfigurationComponent
    {
        public const string DataUrlParameter = "DataUrl";
        public const string FilesContainer = "blogfiles";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; } = null!;

        private string? _dataUrl;

        protected override void OnInitialized()
        {
            _dataUrl = Configuration["BlogDataUrl"];
        }
    }
}
