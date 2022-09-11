namespace Notes.Web.Dtos.Account.Register;

public class RegistrationResponseDto
{
    public IEnumerable<string> Errors { get; set; } = default!;
    public bool IsSuccessfulRegistration { get; internal set; } = default!;
}
