using Notes.Web.Models.AccountModels;
using Notes.Web.Models.AccountModels.Login;
using Notes.Web.Models.AccountModels.Logout;
using Notes.Web.Models.AccountModels.Refresh;
using Notes.Web.Models.AccountModels.Register;

namespace Notes.Web.Services.Interfaces;

public interface IIdentityService
{
    Task<AuthResponseDto> LoginAsync(LoginDto request);
    Task<AuthResponseDto> RegisterAsync(RegisterDto request);
    Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto tokenDto);
    Task LogoutAsync(LogoutDto request);
}
