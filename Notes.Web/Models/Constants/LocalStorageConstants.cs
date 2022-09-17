namespace Notes.Web.Models.Constants;

public static class LocalStorageConstants
{
    public static string AuthToken { get; set; } = "authToken";
    public static string RefreshToken { get; set; } = "refreshToken";
    public static string RefreshTokenExpiryTime { get; set; } = "refreshTokenExpiry";
}
