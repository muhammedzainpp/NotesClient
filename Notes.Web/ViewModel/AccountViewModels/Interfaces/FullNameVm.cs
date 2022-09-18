using Notes.Web.Models;

namespace Notes.Web.ViewModel.AccountViewModels.Interfaces;

public class FullNameVm : IFullNameVm
{
    private readonly ISettings _settings;
    private string _firstName = default!;

    public FullNameVm(ISettings settings) => _settings = settings;

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
