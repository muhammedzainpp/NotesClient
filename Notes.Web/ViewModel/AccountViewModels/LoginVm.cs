using Microsoft.AspNetCore.Components;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.ViewModel.Base;

namespace Notes.Web.ViewModel.AccountViewModels;

public class LoginVm : BaseVm, ILoginVm
{
    private readonly NavigationManager _navigationManager;
    private readonly CustomStateProvider authStateProvider;

    public LoginVm(IApiService apiService, NavigationManager navigation, CustomStateProvider authStateProvider) 
        : base(apiService)
    {
        _navigationManager = navigation;
        this.authStateProvider = authStateProvider;
    }

    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string AtConstant { get; set; } = "@";
    public bool RememberMe { get; set; }

    public async Task LoginAsync()
    {
        var request = new LoginCommand 
        { 
            Email = Email, 
            Password = Password,
            RememberMe = RememberMe,    
        };

        try
        {
            await authStateProvider.LoginAsync(request);
            _navigationManager.NavigateTo("/");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
