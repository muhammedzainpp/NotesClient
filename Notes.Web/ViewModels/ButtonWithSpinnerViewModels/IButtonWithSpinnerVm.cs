namespace Notes.Web.ViewModels.ButtonWithSpinnerViewModels;

public interface IButtonWithSpinnerVm
{
    bool IsBusy { get; set; }
    Action? NotifyStateHasChanged { get; set; }
}