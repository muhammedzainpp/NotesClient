using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;

namespace Notes.Web.Views.AccountViews;

public partial class LoginView
{
    [Inject]
    public ILoginVm Vm { get; set; } = default!;
}
