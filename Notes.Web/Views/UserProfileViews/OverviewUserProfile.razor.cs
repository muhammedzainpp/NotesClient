using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

namespace Notes.Web.Views.UserProfileViews;

public partial class OverviewUserProfile : ComponentBase
{
    [Parameter]
    public IUserProfileVm? Vm { get; set; }
}