using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

namespace Notes.Web.Views.UserProfileViews;

public partial class EditUserProfileView : ComponentBase
{
    [Inject]
    public IEditUserProfileVm Vm { get; set; } = default!;
}
