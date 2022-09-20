using Notes.Web.Models.AccountModels.Register;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;

namespace Notes.Web.ViewModels.AccountViewModels;

public class RegisterVm : IRegisterVm
{
    private readonly IIdentityService _identityService;
    private readonly CustomStateProvider _authState;

    public RegisterVm(IIdentityService identityService, CustomStateProvider authState)
    {
        _identityService = identityService;
        _authState = authState;
    }

    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
    public string AtConstant { get; set; } = "@";

    public async Task RegisterUserAsync()
    {
        var request = new RegisterDto
        {
            Email = Email,
            Password = Password,
            FirstName = FirstName,
            LastName = LastName,
        };

        var result = await _identityService.RegisterAsync(request);

        _authState.NotifyAuthStateChanged(result.Claims);
    }
}
