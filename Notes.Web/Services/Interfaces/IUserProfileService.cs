using Notes.Web.Models.UserProfileModels.GetUserProfileQuery;
using Notes.Web.Models.UserProfileModels.SaveUserProfileCommand;

namespace Notes.Web.Services.Interfaces;

public partial interface IUserProfileService
{
    Task<int> SaveUserAsync(SaveUserProfileCommand request);
    Task<GetUserProfileDto?> GetUserAsync(int id);
}
