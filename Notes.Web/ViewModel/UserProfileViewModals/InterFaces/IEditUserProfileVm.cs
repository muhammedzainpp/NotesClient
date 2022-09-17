namespace Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

public interface IEditUserProfileVm
{
    string? About { get; set; }
    string? Address { get; set; }
    string? Country { get; set; }
    string? Email { get; set; }
    string? FacebookUrl { get; set; }
    string? FullName { get; set; }
    string? InstagamUrl { get; set; }
    string? Phone { get; set; }
    string? TwitterUrl { get; set; }
    Task SaveAsync();

}