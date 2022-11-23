using Microsoft.AspNetCore.Components;

namespace Blog.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        private IList<string> _additionalTagClasses = new List<string>
        {
            "hover"
        };
    }
}
