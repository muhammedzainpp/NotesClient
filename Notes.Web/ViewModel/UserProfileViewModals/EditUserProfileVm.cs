using Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

namespace Notes.Web.ViewModel.UserProfileViewModals;

public class EditUserProfileVm : IEditUserProfileVm
{
    public string? FullName { get; set; }
    public string? About { get; set; }
    public string? Country { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? TwitterUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? InstagamUrl { get; set; }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }
}
