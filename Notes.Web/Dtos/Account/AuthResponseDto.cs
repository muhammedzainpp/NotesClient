using System.Security.Claims;

namespace Notes.Web.Dtos.Account;

public class AuthResponseDto
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
    public List<MyClaim>? Claims { get; set; }
}


public class MyClaim : Claim
{
    public MyClaim(string type, string value, string valueType, string issuer, string originalIssuer) :
        base(type, value, valueType, issuer, originalIssuer)
    { }
}
