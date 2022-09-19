namespace Notes.Web.ViewModel.ButtonWithSpinnerViewModel;

public class ButtonWithSpinnerVm : IButtonWithSpinnerVm
{
    private bool _isBusy;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            NotifyStateHasChanged?.Invoke();
        }
    }
    public Action? NotifyStateHasChanged { get; set; }
}
