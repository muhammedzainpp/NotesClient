using Notes.Web.Dtos.Account.Register;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.ViewModel.Base;

namespace Notes.Web.ViewModel.AccountViewModels;

public class RegisterVm : BaseVm, IRegisterVm
{
    public RegisterVm(IApiService apiService) : base(apiService)
    {
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
            ConfirmPassword = ConfirmPassword
        };

        await _apiService.RegisterUserAsync(request);
    }
}
