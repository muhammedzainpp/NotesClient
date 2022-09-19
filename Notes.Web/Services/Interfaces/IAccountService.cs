using Notes.Web.Dtos.Account;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Logout;
using Notes.Web.Dtos.Account.Refresh;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services.Interfaces;

public interface IAccountService
{
    Task<AuthResponseDto> RegisterUserAsync(RegisterDto request);
    Task<AuthResponseDto> LoginAsync(LoginDto request);
    Task LogoutAsync(LogoutDto request);
    Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto tokenDto);
}
