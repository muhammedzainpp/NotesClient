namespace Notes.Web.ViewModel.ButtonWithSpinnerViewModel;

public interface IButtonWithSpinnerVm
{
    bool IsBusy { get; set; }
    Action? NotifyStateHasChanged { get; set; }
}