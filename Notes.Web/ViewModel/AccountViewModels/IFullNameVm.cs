namespace Notes.Web.ViewModel.AccountViewModels
{
    public interface IFullNameVm
    {
        string FirstName { get; set; }
        Action? NotifyStateChanged { get; set; }
    }
}