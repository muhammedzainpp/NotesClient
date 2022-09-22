using Microsoft.AspNetCore.Components;

namespace Notes.Web.Views.Components.HelperComponents;

public partial class If
{
    [Parameter]
    public bool IsTrue { get; set; }

    [Parameter]
    public RenderFragment? @ChildContent { get; set; }
}
