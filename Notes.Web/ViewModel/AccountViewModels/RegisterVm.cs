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
    private readonly CustomStateProvider authStateProvider;

    public RegisterVm(IApiService apiService, NavigationManager navigationManager, 
        CustomStateProvider authStateProvider) : base(apiService)
    {
        _navigationManager = navigationManager;
        this.authStateProvider = authStateProvider;
    }
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
    public string AtConstant { get; set; } = "@";

    public async Task RegisterUserAsync()
    {
        var request = new RegisterCommand
        {
            Email = Email,
            Password = Password,
            //ConfirmPassword = ConfirmPassword,
            FirstName = FirstName,
            LastName = LastName,
        };

        try
        {
            await authStateProvider.RegisterAsync(request);
            _navigationManager.NavigateTo("/");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
