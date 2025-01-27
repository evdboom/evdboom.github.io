using Microsoft.AspNetCore.Components;
using OptionA.Blazor.Components;

namespace Blog.Shared
{
    public partial class HeaderContent
    {
        [CascadingParameter(Name = OptAResponsive.ValidDimensionsParameterName)]
        public List<string> Dimensions { get; set; } = [];
        [Parameter]
        public bool ShowToggler { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        
        private bool _open = true;
    }
}
