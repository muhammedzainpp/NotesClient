using System.Security.Claims;

namespace Notes.Web.Dtos.Account;

public class AuthClaim : Claim
{
    public AuthClaim(string type, string value, string valueType, string issuer, string originalIssuer) :
        base(type, value, valueType, issuer, originalIssuer)
    { }
}
