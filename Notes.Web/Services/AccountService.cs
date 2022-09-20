using Notes.Web.Models.AccountModels;
using Notes.Web.Models.AccountModels.Login;
using Notes.Web.Models.AccountModels.Logout;
using Notes.Web.Models.AccountModels.Refresh;
using Notes.Web.Models.AccountModels.Register;
using Notes.Web.Services.Interfaces;

namespace Notes.Web.Services;

public class AccountService  : IAccountService
{
    private readonly IApiService _apiService;

    public AccountService(IApiService apiService) => _apiService = apiService;

    public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto request)
    {
        var url = "Account/Registration";
        var response = await _apiService.PostAsync<RegisterDto, AuthResponseDto>(request, url);

        return response;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto request)
    {
        var url = "Account/Login";
        var response = await _apiService.PostAsync<LoginDto, AuthResponseDto>(request, url, false);

        return response;
    }

    public async Task LogoutAsync(LogoutDto request) =>
        await _apiService.PostAsync(request, "Account/logout");

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto request)
    {
        var url = "Account/refreshToken";
        var response = await _apiService.PostAsync<RefreshTokenDto, AuthResponseDto>(request, url, false);

        return response;
    }
}
