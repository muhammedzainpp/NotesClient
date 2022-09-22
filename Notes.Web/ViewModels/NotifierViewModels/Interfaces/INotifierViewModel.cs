using Notes.Web.Models.Enums;

namespace Notes.Web.ViewModels.NotifierViewModels.Interfaces
{
    public interface INotifierViewModel
    {
        string? ShowCss { get; }
        string? Message { get; }
        Action? NotifyStateChanged { get; set; }
        void Close();
        string GetButtonCss();
        string GetColorCss();
        string GetIconCss();
        void Show(NotifierType type, string message);
    }
}