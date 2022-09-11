namespace Notes.Web.ViewModel.AccountViewModels.Interfaces;

public interface IRegisterVm
{
    string ConfirmPassword { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    Task RegisterUserAsync();
}