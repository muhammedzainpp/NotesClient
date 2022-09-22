using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.NotifierViewModels.Interfaces;

namespace Notes.Web.Views.Components.NotifierComponents;

public partial class NotifierContainer
{
    [Inject]
    public INotifierContainerVm Vm { get; set; } = default!;
}
