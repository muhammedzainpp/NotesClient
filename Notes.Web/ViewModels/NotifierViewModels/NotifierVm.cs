using Notes.Web.Models.Enums;
using Notes.Web.ViewModels.NotifierViewModels.Interfaces;

namespace Notes.Web.ViewModels.NotifierViewModels;

public class NotifierVm : INotifierVm
{
    private const string _show = "show";
    private NotifierType Type { get; set; }
    public string? ShowCss { get; private set; }
    public string? Message { get; private set; }
    public Action? NotifyStateChanged { get; set; }

    public string GetColorCss() =>
        Type switch
        {
            NotifierType.Success => "bg-success text-light",
            NotifierType.Error => "bg-danger text-light",
            NotifierType.Warning => "bg-warning",
            _ => "bg-success text-light"
        };

    public string GetIconCss() =>
        Type switch
        {
            NotifierType.Success => "bi bi-check-circle",
            NotifierType.Error => "bi bi-exclamation-octagon",
            NotifierType.Warning => "bi bi-exclamation-triangle ",
            _ => "bi bi-check-circle"
        };

    public string GetButtonCss() =>
        Type switch
        {
            NotifierType.Success => "btn-close-white",
            NotifierType.Error => "btn-close-white",
            NotifierType.Warning => "",
            _ => "btn-close-white"
        };

    public void Show(NotifierType type, string message)
    {
        Type = type;
        Message = message;  
        ShowCss = _show;
        NotifyStateChanged?.Invoke();
    }

    public void Close()
    {
        ShowCss = string.Empty;
        NotifyStateChanged?.Invoke();
    }
}
