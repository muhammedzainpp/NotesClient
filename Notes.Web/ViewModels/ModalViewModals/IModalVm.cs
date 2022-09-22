using Microsoft.AspNetCore.Components;

namespace Notes.Web.ViewModels.ModalViewModals
{
    public interface IModalVm
    {
        RenderFragment? Body { get; }
        string? CancelButtonText { get; }
        string? ConfirmButtonText { get; }
        string? Header { get; }
        Action? OnCancel { get; set; }
        Func<Task<bool>>? OnConfirm { get; set; }

        Task CloseAsync();
        Task ConfirmAsync();
        Task InitJsModuleAsync();
        Task OpenAsync(string header, RenderFragment body, string confirmButtonText, string cancelButtonText);
    }
}