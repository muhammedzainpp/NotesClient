namespace Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

public interface IUserProfileVm
{
    string? About { get; set; }
   
    string? Email { get; set; }
    string? FacebookUrl { get; set; }
    string FirstName { get; set; }
    string? LastName { get; set; }
    string? InstagamUrl { get; set; }
    string? Phone { get; set; }
    string? TwitterUrl { get; set; }
    Action? NotifyStateChanged { get; set; }
    Task SaveAsync();
    Task GetUserProfileAsync();

}