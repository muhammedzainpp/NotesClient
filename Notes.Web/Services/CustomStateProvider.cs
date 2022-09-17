using Microsoft.AspNetCore.Components.Authorization;
using Notes.Web.Services.Interfaces;
using System.Security.Claims;
using Blazored.LocalStorage;
using Notes.Web.Models.Constants;
using Notes.Web.Dtos.Account.Refresh;
using Notes.Web.Dtos.Account;

namespace Notes.Web.Services;

public class CustomStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly IIdentityService _identityService;
    private readonly AuthenticationState _anonymous;
    public CustomStateProvider(ILocalStorageService localStorage, IIdentityService identityService)
    {
        _localStorage = localStorage;
        _identityService = identityService;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var refreshToken = await _localStorage.GetItemAsync<string>(LocalStorageConstants.RefreshToken);
        var refreshTokenExpiry = await _localStorage.GetItemAsync<string>(LocalStorageConstants.RefreshTokenExpiryTime);
        var token = await _localStorage.GetItemAsync<string>(LocalStorageConstants.AuthToken);

        if (string.IsNullOrWhiteSpace(refreshToken) || string.IsNullOrWhiteSpace(refreshTokenExpiry)
            || DateTimeOffset.Parse(refreshTokenExpiry).UtcDateTime <= DateTimeOffset.UtcNow
            || string.IsNullOrWhiteSpace(token))
            return _anonymous;

        var request = new RefreshTokenDto { RefreshToken = refreshToken, Token = token };

        var result = await _identityService.RefreshTokenAsync(request);

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(result.Claims, "jwtAuthType")));
    }

    public void NotifyAuthStateChanged(List<AuthClaim>? claims = null)
    {
        var task = (claims is null) ?
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))) ://anonymous
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuthType"))));

        NotifyAuthenticationStateChanged(task);
    }
}
