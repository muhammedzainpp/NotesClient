using Notes.Web.Models.Constants;
using Notes.Web.Models.Enums;
using Notes.Web.Models.LabelModels.Commands;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModels.ButtonWithSpinnerViewModels;
using Notes.Web.ViewModels.LabelViewModels.Interfaces;
using Notes.Web.ViewModels.NotifierViewModels.Interfaces;

namespace Notes.Web.ViewModels.LabelViewModels;

public class SaveLabelVm : ISaveLabelVm
{
    private readonly ILabelService _serivice;
    private readonly INotifierVm _notifierVm;

    public SaveLabelVm(
        ILabelService serivice, 
        IButtonWithSpinnerVm spinnerVm, 
        INotifierVm notifierVm)
    {
        _serivice = serivice;
        SpinnerVm = spinnerVm;
        _notifierVm = notifierVm;
    }

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public int UserId { get; set; }
    public IButtonWithSpinnerVm SpinnerVm { get; set; }

    public async Task SaveAsync()
    {
        SpinnerVm.IsBusy = true;
        var command = new SaveLabelCommand
        {
            Id = Id,
            Title = Title,
            Description = Description,
            UserId = UserId
        };

        await _serivice.SaveLabelAsync(command);
        SpinnerVm.IsBusy = false;
        _notifierVm.Show(NotifierType.Success,NotifierConstants.SuccessFullySaved);
    }

}
