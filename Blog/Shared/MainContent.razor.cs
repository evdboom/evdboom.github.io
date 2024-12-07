using Microsoft.AspNetCore.Components;
using OptionA.Blazor.Components;

namespace Blog.Shared
{
    public partial class MainContent
    {
        private const string NormalModeFrom = "Large";

        [CascadingParameter(Name = OptAResponsive.ValidDimensionsParameterName)]
        public IEnumerable<string>? ValidDimensions { get; set; }        
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private bool SmallMode => ValidDimensions is null || !ValidDimensions.Contains(NormalModeFrom);
        private Dictionary<string, object?> GetBarAttributes()
        {
            var result = new Dictionary<string, object?>();

            if (SmallMode) 
            {
                result["small"] = true;
            }

            return result;
        }
    }
}
