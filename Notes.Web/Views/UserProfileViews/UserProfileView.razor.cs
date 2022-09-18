using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

namespace Notes.Web.Views.UserProfileViews;

public partial class UserProfileView : IDisposable
{
    [Inject]
    public IUserProfileVm Vm { get; set; } = default!;


    protected override async Task OnInitializedAsync()
    {
        await Vm.GetUserProfileAsync();
        Vm.NotifyStateChanged += StateHasChanged;
    }
    public void Dispose() => 
        Vm.NotifyStateChanged -= StateHasChanged;
}
