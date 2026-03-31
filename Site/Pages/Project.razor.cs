using Microsoft.AspNetCore.Components;

namespace OptionA.Site.Pages;

public partial class Project
{
    [Parameter]
    public string? ProjectName { get; set; }
}
