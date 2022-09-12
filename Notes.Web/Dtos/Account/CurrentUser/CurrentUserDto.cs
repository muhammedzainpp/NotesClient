﻿namespace Notes.Web.Dtos.Account.CurrentUser;

public class CurrentUserDto
{
    public bool IsAuthenticated { get; set; }
    public string? UserName { get; set; }
    public Dictionary<string, string>? Claims { get; set; }
}
