using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Refresh;
using Notes.Web.Dtos.Account.Register;
using Notes.Web.Dtos.Account;
using Notes.Web.Dtos.Account.Logout;

namespace Notes.Web.Services.Interfaces;

public interface IIdentityService
{
    Task<AuthResponseDto> LoginAsync(LoginDto request);
    Task<AuthResponseDto> RegisterAsync(RegisterDto request);
    Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto tokenDto);
    Task LogoutAsync(LogoutDto request);
}
