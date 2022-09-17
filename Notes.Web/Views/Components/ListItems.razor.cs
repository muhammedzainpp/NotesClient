using Microsoft.AspNetCore.Components;

namespace Notes.Web.Views.Components
{
    public partial class ListItems<TItem>
    {
        [Parameter]
        public RenderFragment<TItem>? ItemTemplate { get; set; }

        [Parameter]
        public IEnumerable<TItem>? Items { get; set; }
    }
}
