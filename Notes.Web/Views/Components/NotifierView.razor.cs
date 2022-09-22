using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.NotifierViewModels;

namespace Notes.Web.Views.Components;

public partial class NotifierView : ComponentBase, IDisposable
{
    [Inject]
    public INotifierViewModel Vm { get; set; } = default!;


    protected override void OnInitialized() => 
        Vm.NotifyStateChanged += StateHasChanged;

    void IDisposable.Dispose() => Vm.NotifyStateChanged -= StateHasChanged;
}
