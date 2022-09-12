namespace Notes.Web.Dtos.Account.Login;

public class LoginCommand
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool RememberMe { get; set; }
}

