namespace Notes.Web.ViewModels.AccountViewModels.Interfaces;

public interface IFullNameVm
{
    string FirstName { get; set; }
    Action? NotifyStateChanged { get; set; }
}