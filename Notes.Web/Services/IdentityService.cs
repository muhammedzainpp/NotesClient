using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Refresh;
using Notes.Web.Dtos.Account.Register;
using Notes.Web.Dtos.Account;
using Notes.Web.Models.Constants;
using Notes.Web.Services.Interfaces;
using Blazored.LocalStorage;
using Notes.Web.Dtos.Account.Logout;

namespace Notes.Web.Services;

public class IdentityService : IIdentityService
{
    private readonly IApiService _apiService;
    private readonly ILocalStorageService _localStorage;

    public IdentityService(IApiService apiService, ILocalStorageService localStorage)
    {
        _apiService = apiService;
        _localStorage = localStorage;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto request)
    {
        var result = await _apiService.LoginAsync(request);

        await OnSuccessfulAuthentication(result);

        return result;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto request)
    {
        var result = await _apiService.RegisterUserAsync(request);

        await OnSuccessfulAuthentication(result);

        return result;
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto request)
    {
        var result = await _apiService.RefreshTokenAsync(request);

        await OnSuccessfulAuthentication(result);

        return result;
    }

    public async Task LogoutAsync(LogoutDto request)
    {
        await _apiService.LogoutAsync();

        await _localStorage.RemoveItemAsync(LocalStorageConstants.AuthToken);
        await _localStorage.RemoveItemAsync(LocalStorageConstants.RefreshToken);
        await _localStorage.RemoveItemAsync(LocalStorageConstants.RefreshTokenExpiryTime);
    }

    private async Task OnSuccessfulAuthentication(AuthResponseDto result)
    {
        await _localStorage.SetItemAsync(LocalStorageConstants.AuthToken, result.Token);
        await _localStorage.SetItemAsync(LocalStorageConstants.RefreshToken, result.RefreshToken);
        await _localStorage.SetItemAsync(LocalStorageConstants.RefreshTokenExpiryTime, result.RefreshTokenExpiryTime.ToString());
    }   
}
