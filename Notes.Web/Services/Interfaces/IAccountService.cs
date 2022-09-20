using Notes.Web.Models.AccountModels;
using Notes.Web.Models.AccountModels.Login;
using Notes.Web.Models.AccountModels.Logout;
using Notes.Web.Models.AccountModels.Refresh;
using Notes.Web.Models.AccountModels.Register;

namespace Notes.Web.Services.Interfaces;

public interface IAccountService
{
    Task<AuthResponseDto> RegisterUserAsync(RegisterDto request);
    Task<AuthResponseDto> LoginAsync(LoginDto request);
    Task LogoutAsync(LogoutDto request);
    Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto tokenDto);
}
