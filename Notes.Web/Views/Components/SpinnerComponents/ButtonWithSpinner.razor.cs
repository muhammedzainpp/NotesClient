using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.ButtonWithSpinnerViewModels;

namespace Notes.Web.Views.Components.SpinnerComponents;

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
