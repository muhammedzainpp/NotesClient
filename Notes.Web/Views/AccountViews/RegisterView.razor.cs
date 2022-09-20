using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;

namespace Notes.Web.Views.AccountViews;

public partial class RegisterView : ComponentBase
{
    [Inject]
    public IRegisterVm Vm { get; set; } = default!;
}
