using Notes.Web.ViewModels.NotifierViewModels.Interfaces;

namespace Notes.Web.ViewModels.NotifierViewModels;

public class NotifierContainerVm : INotifierContainerVm
{
    public List<INotifierViewModel>? NotifierViewModels { get; set; }
}
