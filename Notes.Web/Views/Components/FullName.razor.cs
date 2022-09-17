using Microsoft.AspNetCore.Components;
using Notes.Web.Models;

namespace Notes.Web.Views.Components;

public partial class FullName
{
    [Inject]
    public Settings Settings { get; set; } = default!;
}
    
