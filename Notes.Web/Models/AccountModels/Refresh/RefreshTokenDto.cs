namespace Notes.Web.Models.AccountModels.Refresh;

public class RefreshTokenDto
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}
