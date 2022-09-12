using Notes.Web.Dtos.Account.CurrentUser;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services.Interfaces;

public partial interface IApiService
{
    Task RegisterUserAsync(RegisterCommand request);
    Task LoginAsync(LoginCommand request);
    Task Logout();
    Task<CurrentUserDto> CurrentUserInfo();
}
