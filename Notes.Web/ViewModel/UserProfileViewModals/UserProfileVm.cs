using Notes.Web.Dtos.UserProfile.GetUserProfileQuery;
using Notes.Web.Dtos.UserProfile.SaveUserProfileCommand;
using Notes.Web.Models;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

namespace Notes.Web.ViewModel.UserProfileViewModals;

public class UserProfileVm : IUserProfileVm
{
    private readonly ISettings _settings;
    private readonly IFullNameVm _fullNameVm;
    private readonly IUserProfileService _service;

    public UserProfileVm(IApiService apiService, ISettings settings, IFullNameVm fullNameVm,
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
        MapToVm(result);
    }

    private void MapToVm(GetUserProfileDto? result)
    {
        if (result is null) return;

        Id = result.Id;
        AppUserId = result.AppUserId;
        FirstName = result.FirstName;
        LastName = result.LastName;
        About = result.About;
        Phone = result.Phone;
        Email = result.Email;
        TwitterUrl = result.TwitterUrl;
        FacebookUrl = result.FacebookUrl;
        InstagamUrl = result.InstagamUrl;
    }

    public async Task SaveAsync()
    {
        var request = MapToSaveUserProfileCommand();

        await _service.SaveUserAsync(request);

        await GetUserProfileAsync();

        NotifyStateChanged?.Invoke();

        _fullNameVm.FirstName = FirstName;
    }

    private SaveUserProfileCommand MapToSaveUserProfileCommand() =>
     new()
     {
         Id = Id,
         AppUserId = AppUserId,
         FirstName = FirstName,
         LastName = LastName,
         About = About,
         Phone = Phone,
         Email = Email,
         TwitterUrl = TwitterUrl,
         FacebookUrl = FacebookUrl,
         InstagamUrl = InstagamUrl,
     };
}
