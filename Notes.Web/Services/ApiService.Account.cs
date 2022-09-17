using Notes.Web.Dtos.Account;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Refresh;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services;

public partial class ApiService
{
    public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto request)
    {
        var url = "Account/Registration";
        var response = await PostAsync<RegisterDto, AuthResponseDto>(request, url);

        return response;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto request)
    {
        var url = "Account/Login";
        var response = await PostAsync<LoginDto, AuthResponseDto>(request, url, false);

        return response;
    }

    public async Task LogoutAsync() =>
        await PostAsync<object>(null, "Account/logout");

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto request)
    {
        var url = "Account/refreshToken";
        var response = await PostAsync<RefreshTokenDto, AuthResponseDto>(request, url, false);

        return response;
    }
}
