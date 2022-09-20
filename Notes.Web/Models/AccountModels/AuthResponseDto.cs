namespace Notes.Web.Models.AccountModels;

public class AuthResponseDto
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
    public List<AuthClaim>? Claims { get; set; }
}
