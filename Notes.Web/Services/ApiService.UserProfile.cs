using Notes.Web.Dtos.UserProfile.GetUserProfileQuery;
using Notes.Web.Dtos.UserProfile.SaveUserProfileCommand;

namespace Notes.Web.Services;

public partial class ApiService
{
    public async Task<int> SaveUserAsync(SaveUserProfileCommand request)
    {
        var url = "userprofile";
        var response = await PostAsync<SaveUserProfileCommand,int>(request,url);
        return response;
    }

    public async Task<GetUserProfileDto?> GetUserAsync(int id)
    {
        var url = $"userprofile/{id}";
        var response = await GetAsync<GetUserProfileDto>(url);
        return response;
    }
}
