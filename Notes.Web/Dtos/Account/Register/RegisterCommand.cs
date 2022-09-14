namespace Notes.Web.Dtos.Account.Register;

public class RegisterCommand
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
    //public string ConfirmPassword { get; set; } = default!;
}
