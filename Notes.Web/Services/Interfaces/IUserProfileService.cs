using Notes.Web.Dtos.UserProfile.GetUserProfileQuery;
using Notes.Web.Dtos.UserProfile.SaveUserProfileCommand;

namespace Notes.Web.Services.Interfaces;

public partial interface IUserProfileService
{
    Task<int> SaveUserAsync(SaveUserProfileCommand request);
    Task<GetUserProfileDto?> GetUserAsync(int id);
}
