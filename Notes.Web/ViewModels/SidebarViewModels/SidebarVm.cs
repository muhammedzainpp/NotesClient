using static Notes.Web.Models.SidebarModels.SidebarVm;

namespace Notes.Web.ViewModels.SidebarViewModels;

public class SidebarVm : ISidebarVm
{
    public List<SidebarItemModel> Items { get; set; } = new();

    public void AddToList(string name, string url, bool isActive, string iconClassName)
    {
        var item = new SidebarItemModel(name, url, isActive, iconClassName);
        Items.Add(item);
    }

    public void OnLocationChanged(SidebarItemModel item) => 
        Items.ForEach(i => i.IsActive = i.Url == item.Url);
}
