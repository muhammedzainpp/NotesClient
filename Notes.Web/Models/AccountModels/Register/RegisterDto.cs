namespace Notes.Web.Models.AccountModels.Register;

public class RegisterDto
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
    //public string ConfirmPassword { get; set; } = default!;
}
