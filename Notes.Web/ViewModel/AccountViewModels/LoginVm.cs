using Microsoft.AspNetCore.Components.Authorization;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;

namespace Notes.Web.ViewModel.AccountViewModels;

public class LoginVm : ILoginVm
{
    private readonly IIdentityService _identityService;
    private readonly CustomStateProvider _authState;

    public LoginVm(IIdentityService identityService, AuthenticationStateProvider authState)
    {
        _identityService = identityService;
        _authState = (authState as CustomStateProvider)!;
    }

    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string AtConstant { get; set; } = "@";

    public async Task LoginAsync()
    {
        var request = new LoginDto
        {
            Email = Email,
            Password = Password
        };

        var result = await _identityService.LoginAsync(request);

        _authState.NotifyAuthStateChanged(result.Claims);
    }
}
