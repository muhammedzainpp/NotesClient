using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Notes.Web.ViewModels.SidebarViewModels;

namespace Notes.Web.Views.Components.SidebarComponents;

public partial class Sidebar
{
    [Inject]
    public ISidebarVm Vm { get; set; } = default!;

    protected override void OnInitialized()
    {
        Vm.AddToList("Notes", "/", true, "bx bx-bulb");

        Vm.AddToList("Labels", "labels", false, "bx bx-tag-alt");

    }

   


   
}
