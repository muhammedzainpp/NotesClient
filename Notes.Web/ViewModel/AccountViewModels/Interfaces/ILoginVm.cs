namespace Notes.Web.ViewModel.AccountViewModels.Interfaces
{
    public interface ILoginVm
    {
        string Email { get; set; }
        string Password { get; set; }
        string AtConstant { get; set; }
        Task LoginAsync();
    }
}