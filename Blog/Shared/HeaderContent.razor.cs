using Microsoft.AspNetCore.Components;

namespace Blog.Shared
{
    public partial class HeaderContent
    {
        [Parameter]
        public bool ShowToggler { get; set; }
        [CascadingParameter(Name = ConfigurationComponent.DataUrlParameter)]
        public string? DataUrl { get; set; }
        private bool _open;
    }
}
