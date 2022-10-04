using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.LabelViewModels.Interfaces;

namespace Notes.Web.Views.LabelsViews;

public partial class SaveLabelView
{
    [Inject]
    public ISaveLabelVm Vm { get; set; } = default!;


}
