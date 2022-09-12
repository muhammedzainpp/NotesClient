namespace Notes.Web.Dtos.Account.Login;

public class AuthResponseDto
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }
}
