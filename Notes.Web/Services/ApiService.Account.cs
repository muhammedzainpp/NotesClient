using Notes.Web.Dtos.Account.CurrentUser;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services;

public partial class ApiService
{
    public  async Task<AuthResponseDto> RegisterUserAsync(RegisterCommand request)
    {
        var url = "Account/Registration";
        var response = await PostAsync<RegisterCommand, AuthResponseDto>(request, url);

        return response;
    }

    public async Task<CurrentUserDto> CurrentUserInfo()
    {
        var result = await GetAsync<CurrentUserDto>("account/currentuserinfo");
        return result!;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginCommand request)
    {
        var url = "Account/Login";
        var response = await PostAsync<LoginCommand, AuthResponseDto>(request, url, false);

        return response;
    }

    public async Task LogoutAsync() => 
        await PostAsync<object>(null, "auth/logout");
}
