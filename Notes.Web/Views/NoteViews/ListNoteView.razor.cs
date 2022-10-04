using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Notes.Web.ViewModels.NoteViewModels.Interfaces;

namespace Notes.Web.Views.NoteViews;

public partial class ListNoteView : ComponentBase
{
    [Inject]
    public IListNoteVm Vm { get; set; } = default!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;
    protected async override Task OnInitializedAsync() => 
        await Vm.GetNotesAsync();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/masonry.js");
            await module.InvokeVoidAsync("initOptionsForLayout");
        }
    }
}
