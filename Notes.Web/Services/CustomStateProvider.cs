using Microsoft.AspNetCore.Components.Authorization;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;
using Notes.Web.Services.Interfaces;
using System.Security.Claims;
using Blazored.LocalStorage;

namespace Notes.Web.Services;

public class CustomStateProvider : AuthenticationStateProvider
{
    private readonly IApiService _apiService;
    //private CurrentUserDto? _currentUser;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationState _anonymous;
    public CustomStateProvider(IApiService apiService, ILocalStorageService localStorage)
    {
        _apiService = apiService;
        _localStorage = localStorage;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        if (string.IsNullOrWhiteSpace(token))
            return _anonymous;

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
    }
    //private async Task<CurrentUserDto> GetCurrentUserAsync()
    //{
    //    if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
    //    _currentUser = await _apiService.CurrentUserInfo();
    //    return _currentUser;
    //}

    public async Task LogoutAsync()
    {
        await _apiService.LogoutAsync();

        await _localStorage.RemoveItemAsync("authToken");
        //_currentUser = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task LoginAsync(LoginCommand command)
    {
        var result = await _apiService.LoginAsync(command);

        await _localStorage.SetItemAsync("authToken", result.Token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task RegisterAsync(RegisterCommand command)
    {
        var result =  await _apiService.RegisterUserAsync(command);

        await _localStorage.SetItemAsync("authToken", result.Token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
