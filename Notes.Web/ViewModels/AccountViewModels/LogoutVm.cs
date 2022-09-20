using Notes.Web.Services.Interfaces;
using Notes.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Notes.Web.Models.Settings;
using Notes.Web.Models.AccountModels.Logout;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;

namespace Notes.Web.ViewModels.AccountViewModels;

public class LogoutVm : ILogoutVm
{
    private readonly IIdentityService _identityService;
    private readonly ISetting _settings;
    private readonly CustomStateProvider _authState;

    public LogoutVm(IIdentityService identityService,
        ISetting settings, AuthenticationStateProvider authState)
    {
        _identityService = identityService;
        _settings = settings;
        _authState = (authState as CustomStateProvider)!;
    }

    public async Task LogoutAsync()
    {
        var request = new LogoutDto
        {
            UserId = _settings.UserId,
        };

        await _identityService.LogoutAsync(request);

        _authState.NotifyAuthStateChanged(null);
    }
}
