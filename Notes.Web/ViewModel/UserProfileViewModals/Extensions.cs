using Notes.Web.Models.UserProfileModels.GetUserProfileQuery;
using Notes.Web.Models.UserProfileModels.SaveUserProfileCommand;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Notes.Web.ViewModel.UserProfileViewModals;

public static class Extensions
{
    public static SaveUserProfileCommand MapToSaveUserProfileCommand(this UserProfileVm vm) =>
     new()
     {
         Id = vm.Id,
         AppUserId = vm.AppUserId,
         FirstName = vm.FirstName,
         LastName = vm.LastName,
         About = vm.About,
         Phone = vm.Phone,
         Email = vm.Email,
         TwitterUrl = vm.TwitterUrl,
         FacebookUrl = vm.FacebookUrl,
         InstagamUrl = vm.InstagamUrl,
     };

    public static void MapToUserProfileVm(this UserProfileVm vm, GetUserProfileDto? result)
    {
        if (result is null) return;

        vm.Id = result.Id;
        vm.AppUserId = result.AppUserId;
        vm.FirstName = result.FirstName;
        vm.LastName = result.LastName;
        vm.About = result.About;
        vm.Phone = result.Phone;
        vm.Email = result.Email;
        vm.TwitterUrl = result.TwitterUrl;
        vm.FacebookUrl = result.FacebookUrl;
        vm.InstagamUrl = result.InstagamUrl;
    }
}
