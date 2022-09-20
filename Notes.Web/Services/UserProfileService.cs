using Notes.Web.Models.UserProfileModels.GetUserProfileQuery;
using Notes.Web.Models.UserProfileModels.SaveUserProfileCommand;
using Notes.Web.Services.Interfaces;

namespace Notes.Web.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IApiService _apiService;

    public UserProfileService(IApiService apiService) => _apiService = apiService;

    public async Task<int> SaveUserAsync(SaveUserProfileCommand request)
    {
        var url = "userprofile";
        var response = await _apiService.PostAsync<SaveUserProfileCommand,int>(request,url);
        return response;
    }

    public async Task<GetUserProfileDto?> GetUserAsync(int id)
    {
        var url = $"userprofile/{id}";
        var response = await _apiService.GetAsync<GetUserProfileDto>(url);
        return response;
    }
}
