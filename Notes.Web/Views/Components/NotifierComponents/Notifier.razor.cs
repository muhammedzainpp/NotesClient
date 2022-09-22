using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.NotifierViewModels.Interfaces;

namespace Notes.Web.Views.Components.NotifierComponents;

public partial class Notifier : ComponentBase, IDisposable
{
    [Inject]
    public INotifierViewModel Vm { get; set; } = default!;


    protected override void OnInitialized() =>
        Vm.NotifyStateChanged += StateHasChanged;

    void IDisposable.Dispose() => Vm.NotifyStateChanged -= StateHasChanged;
}
