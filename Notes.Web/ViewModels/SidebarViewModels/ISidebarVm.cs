

using static Notes.Web.Models.SidebarModels.SidebarVm;

namespace Notes.Web.ViewModels.SidebarViewModels
{
    public interface ISidebarVm
    {
        List<SidebarItemModel> Items { get; set; }
        void AddToList(string name, string url, bool isActive, string iconClassName);
        void OnLocationChanged(SidebarItemModel item);
    }
}