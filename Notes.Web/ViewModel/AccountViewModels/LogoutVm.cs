using Notes.Web.Dtos.Account.Logout;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.Models;
using Notes.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace Notes.Web.ViewModel.AccountViewModels;

public class LogoutVm : ILogoutVm
{
    private readonly IIdentityService _identityService;
    private readonly Settings _settings;
    private readonly CustomStateProvider _authState;

    public LogoutVm(IIdentityService identityService, 
        Settings settings, AuthenticationStateProvider authState)
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
