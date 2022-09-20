using Notes.Web.Models.Settings;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;
using Notes.Web.ViewModels.UserProfileViewModals.InterFaces;

namespace Notes.Web.ViewModels.UserProfileViewModals;

public class UserProfileVm : IUserProfileVm
{
    private readonly ISetting _settings;
    private readonly IFullNameVm _fullNameVm;
    private readonly IUserProfileService _service;

    public UserProfileVm(ISetting settings,
        IFullNameVm fullNameVm,
        IUserProfileService service)
    {
        _settings = settings;
        _fullNameVm = fullNameVm;
        _service = service;
    }

    public int Id { get; set; }
    public string AppUserId { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string? About { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? TwitterUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? InstagamUrl { get; set; }
    public Action? NotifyStateChanged { get; set; }

    public async Task GetUserProfileAsync()
    {
        var result = await _service.GetUserAsync(_settings.UserId);
        this.MapToUserProfileVm(result);
    }

    public async Task SaveAsync()
    {
        var request = this.MapToSaveUserProfileCommand();

        await _service.SaveUserAsync(request);

        await GetUserProfileAsync();

        NotifyStateChanged?.Invoke();

        _fullNameVm.FirstName = FirstName;
    }
}
