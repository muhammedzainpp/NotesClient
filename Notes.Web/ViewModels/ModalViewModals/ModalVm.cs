using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Notes.Web.ViewModels.ModalViewModals;

public class ModalVm : IModalVm
{
    private readonly IJSRuntime _jSRuntime;
    private IJSObjectReference _jsModule = default!;

    public ModalVm(IJSRuntime jSRuntime) => _jSRuntime = jSRuntime;

    public string? Header { get; private set; }
    public RenderFragment? Body { get; private set; }
    public string? ConfirmButtonText { get; private set; }
    public string? CancelButtonText { get; private set; }
    public Action? OnCancel { get; set; }
    public Func<Task<bool>>? OnConfirm { get; set; }

    public async Task InitJsModuleAsync() => 
        _jsModule = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./Scripts/modal.js");

    public async Task OpenAsync(string header, RenderFragment body, string confirmButtonText, string cancelButtonText)
    {
        Header = header;
        Body = body;
        ConfirmButtonText = confirmButtonText;
        CancelButtonText = cancelButtonText;

        await OpenModal();
    }


    public async Task CloseAsync()
    {
        OnCancel?.Invoke();

        await CloseModal();
    }

    public async Task ConfirmAsync()
    {
        var confirmed = false;

        if (OnConfirm is not null)
            confirmed = await OnConfirm.Invoke();

        if (confirmed || OnConfirm is null) await CloseModal();

    }

    private ValueTask CloseModal() => _jsModule.InvokeVoidAsync("closeModal");
    private ValueTask OpenModal() => _jsModule.InvokeVoidAsync("openModal");
}
