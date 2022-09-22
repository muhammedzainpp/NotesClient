using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.ModalViewModals;

namespace Notes.Web.Views.Components.ModalComponents;

public partial class Modal
{
    [Inject]
    public IModalVm Vm { get; set; } = default!;

    protected override Task OnAfterRenderAsync(bool firstRender) =>
        firstRender ? Vm.InitJsModuleAsync() : Task.CompletedTask;
}
