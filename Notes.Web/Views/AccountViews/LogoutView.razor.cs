using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;

namespace Notes.Web.Views.AccountViews;

partial class LogoutView : ComponentBase
{
    [Inject]
    public ILogoutVm Vm { get; set; } = default!;
}
