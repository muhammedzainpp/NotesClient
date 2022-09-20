using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;

namespace Notes.Web.Views.Components;

public partial class FullName : IDisposable
{
    [Inject]
    public IFullNameVm Vm { get; set; } = default!;

    protected override void OnInitialized() => Vm.NotifyStateChanged += StateHasChanged;
    void IDisposable.Dispose() => Vm.NotifyStateChanged -= StateHasChanged;
}
    
