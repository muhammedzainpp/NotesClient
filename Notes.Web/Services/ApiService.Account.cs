using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;
using Notes.Web.Dtos.Notes.SaveNoteCommand;

namespace Notes.Web.Services;

public partial class ApiService
{
    public  async Task<RegistrationResponseDto> RegisterUserAsync(RegisterCommand request)
    {
        var url = "Account/Registration";
        var response = await PostAsync<RegisterCommand, RegistrationResponseDto>(request, url);
        return response;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginCommand request)
    {
        var url = "Account/Login";
        var response = await PostAsync<LoginCommand, AuthResponseDto>(request, url);
        return response;
    }
}
