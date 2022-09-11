using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services.Interfaces;

public partial interface IApiService
{
    Task<RegistrationResponseDto> RegisterUserAsync(RegisterCommand request);
    Task<AuthResponseDto> LoginAsync(LoginCommand request);
}
