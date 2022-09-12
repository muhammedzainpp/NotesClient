using Notes.Web.Dtos.Account.CurrentUser;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services;

public partial class ApiService
{
    public  async Task RegisterUserAsync(RegisterCommand request)
    {
        var url = "Account/Registration";
        await PostAsync(request, url);
    }

    public async Task<CurrentUserDto> CurrentUserInfo()
    {
        var result = await GetAsync<CurrentUserDto>("account/currentuserinfo");
        return result!;
    }

    public async Task LoginAsync(LoginCommand request)
    {
        var url = "Account/Login";
        await PostAsync(request, url);
    }

    public async Task Logout() => 
        await PostAsync<object>(null, "auth/logout");
}
