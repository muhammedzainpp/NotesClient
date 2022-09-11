namespace Notes.Web.Dtos.Account.Login;

public class AuthResponseDto
{
    public bool IsAuthSuccessful { get; set; }
    public string ErrorMessage { get; set; } = default!;
    public string Token { get; set; } = default!;
}
