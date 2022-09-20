using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.UserProfileViewModals.InterFaces;

namespace Notes.Web.Views.UserProfileViews;

public partial class EditUserProfileView : ComponentBase
{
    [Parameter]
    public IUserProfileVm? Vm { get; set; }
}
