using Notes.Web.Models;

namespace Notes.Web.ViewModel.AccountViewModels.Interfaces;

public class FullNameVm : IFullNameVm
{
    private readonly Settings _settings;
    private string _firstName = default!;

    public FullNameVm(Settings settings) => _settings = settings;

    public Action? NotifyStateChanged { get; set; }
    public string FirstName
    {
        get => _firstName is null ? _settings.FirstName : _firstName;

        set
        {
            _firstName = value;
            _settings.FirstName = value;
            NotifyStateChanged?.Invoke();
        }
    }
}
