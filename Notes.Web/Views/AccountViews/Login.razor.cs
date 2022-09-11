﻿using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;

namespace Notes.Web.Views.AccountViews;

public partial class Login
{
    [Inject]
    public ILoginVm Vm { get; set; } = default!;
}
