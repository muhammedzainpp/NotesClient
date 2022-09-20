using Notes.Web.Models.Settings;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;

namespace Notes.Web.ViewModels.AccountViewModels;

public class FullNameVm : IFullNameVm
{
    private readonly ISetting _settings;
    private string _firstName = default!;

    public FullNameVm(ISetting settings) => _settings = settings;

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
