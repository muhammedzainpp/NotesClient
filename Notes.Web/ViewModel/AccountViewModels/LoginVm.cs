using Notes.Web.Dtos.Account.Login;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.ViewModel.Base;

namespace Notes.Web.ViewModel.AccountViewModels;

public class LoginVm : BaseVm, ILoginVm
{
    public LoginVm(IApiService apiService) : base(apiService)
    {
    }

    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public async Task LoginAsync()
    {
        var request = new LoginCommand 
        { 
            Email = Email, 
            Password = Password
        };

        await _apiService.LoginAsync(request);
    }
}
