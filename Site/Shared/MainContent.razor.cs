using Microsoft.AspNetCore.Components;

namespace Blog.Shared
{
    public partial class MainContent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public bool Center { get; set; }

        private Dictionary<string, object?> GetMainAttributes()
        {
            var result = new Dictionary<string, object?>
            {
                ["Center"] = Center
            };

            return result;
        }

    }
}
