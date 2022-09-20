using Notes.Web.Models.Constants;
using Notes.Web.Services.Interfaces;
using Blazored.LocalStorage;
using Notes.Web.Models;
using Notes.Web.Models.AccountModels.Login;
using Notes.Web.Models.AccountModels.Logout;
using Notes.Web.Models.AccountModels.Refresh;
using Notes.Web.Models.AccountModels.Register;
using Notes.Web.Models.AccountModels;
using Notes.Web.Models.Settings;

namespace Notes.Web.Services;

public class IdentityService : IIdentityService
{
    private readonly IAccountService _accountService;
    private readonly ILocalStorageService _localStorage;
    private readonly ISetting _settings;

    public IdentityService(IAccountService accountService, ILocalStorageService localStorage, 
        ISetting settings)
    {
        _accountService = accountService;
        _localStorage = localStorage;
        _settings = settings;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto request)
    {
        var result = await _accountService.LoginAsync(request);

        await OnSuccessfulAuthenticationAsync(result);

        return result;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto request)
    {
        var result = await _accountService.RegisterUserAsync(request);

        await OnSuccessfulAuthenticationAsync(result);

        return result;
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto request)
    {
        var result = await _accountService.RefreshTokenAsync(request);

        await OnSuccessfulAuthenticationAsync(result);

        return result;
    }

    public async Task LogoutAsync(LogoutDto request)
    {
        await _accountService.LogoutAsync(request);

        await _localStorage.RemoveItemAsync(LocalStorageConstants.AuthToken);
        await _localStorage.RemoveItemAsync(LocalStorageConstants.RefreshToken);
        await _localStorage.RemoveItemAsync(LocalStorageConstants.RefreshTokenExpiryTime);
    }

    private async Task OnSuccessfulAuthenticationAsync(AuthResponseDto result)
    {
        _settings.UserId = result.UserId;
        _settings.FirstName = result.FirstName!;

        await _localStorage.SetItemAsync(LocalStorageConstants.AuthToken, result.Token);
        await _localStorage.SetItemAsync(LocalStorageConstants.RefreshToken, result.RefreshToken);
        await _localStorage.SetItemAsync(LocalStorageConstants.RefreshTokenExpiryTime, result.RefreshTokenExpiryTime.ToString());
    }   
}
