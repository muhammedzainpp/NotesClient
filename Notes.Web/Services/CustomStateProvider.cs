using Microsoft.AspNetCore.Components.Authorization;
using Notes.Web.Dtos.Account.CurrentUser;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;
using Notes.Web.Services.Interfaces;
using System.Security.Claims;

namespace Notes.Web.Services;

public class CustomStateProvider : AuthenticationStateProvider
{
    private readonly IApiService _apiService;
    private CurrentUserDto? _currentUser;
    public CustomStateProvider(IApiService apiService) => 
        _apiService = apiService;
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        try
        {
            var userInfo = await GetCurrentUser();
            if (userInfo.IsAuthenticated && _currentUser is not null)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName!) }.Concat(_currentUser.Claims!.Select(c => new Claim(c.Key, c.Value)));
                identity = new ClaimsIdentity(claims, "Server authentication");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString());
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
    private async Task<CurrentUserDto> GetCurrentUser()
    {
        if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
        _currentUser = await _apiService.CurrentUserInfo();
        return _currentUser;
    }
    public async Task Logout()
    {
        await _apiService.Logout();
        _currentUser = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task Login(LoginCommand loginParameters)
    {
        await _apiService.LoginAsync(loginParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Register(RegisterCommand registerParameters)
    {
        await _apiService.RegisterUserAsync(registerParameters);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
