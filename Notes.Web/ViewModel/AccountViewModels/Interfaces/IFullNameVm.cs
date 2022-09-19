namespace Notes.Web.ViewModel.AccountViewModels.Interfaces
{
    public interface IFullNameVm
    {
        string FirstName { get; set; }
        Action? NotifyStateChanged { get; set; }
    }
}