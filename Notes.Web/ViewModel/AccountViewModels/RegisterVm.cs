using Microsoft.AspNetCore.Components;
using Notes.Web.Dtos.Account.Register;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.ViewModel.Base;

namespace Notes.Web.ViewModel.AccountViewModels;

public class RegisterVm : BaseVm, IRegisterVm
{
    private readonly NavigationManager _navigationManager;
    private readonly IIdentityService _identityService;
    private readonly CustomStateProvider _authState;

    public RegisterVm(IApiService apiService, NavigationManager navigationManager,
        IIdentityService identityService, CustomStateProvider authState) : base(apiService)
    {
        _navigationManager = navigationManager;
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
        _navigationManager.NavigateTo("/");
    }
}
