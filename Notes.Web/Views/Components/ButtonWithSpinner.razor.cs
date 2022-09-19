using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModel.ButtonWithSpinnerViewModel;

namespace Notes.Web.Views.Components;

public partial class ButtonWithSpinner : ComponentBase, IDisposable
{
    [Parameter]
    public IButtonWithSpinnerVm? Vm { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }


    protected override void OnInitialized() => 
        Vm!.NotifyStateHasChanged += StateHasChanged;

    void IDisposable.Dispose() => 
        Vm!.NotifyStateHasChanged -= StateHasChanged;
}
