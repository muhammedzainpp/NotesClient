﻿using Notes.Web.Dtos.Account;
using Notes.Web.Dtos.Account.Login;
using Notes.Web.Dtos.Account.Refresh;
using Notes.Web.Dtos.Account.Register;

namespace Notes.Web.Services.Interfaces;

public partial interface IApiService
{
    Task<AuthResponseDto> RegisterUserAsync(RegisterDto request);
    Task<AuthResponseDto> LoginAsync(LoginDto request);
    Task LogoutAsync();
    Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto tokenDto);
}
