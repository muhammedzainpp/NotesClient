using Notes.Web.Dtos.Account.CurrentUser;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services.Interfaces;

public partial interface IApiService
{
    Task<AuthResponseDto> RegisterUserAsync(RegisterCommand request);
    Task<AuthResponseDto> LoginAsync(LoginCommand request);
    Task LogoutAsync();
    Task<CurrentUserDto> CurrentUserInfo();
}
