namespace Notes.Web.Models.SidebarModels;

public class SidebarVm
{
    public class SidebarItemModel
    {
        public SidebarItemModel(string name, string url, bool isActive, string iconClassName)
        {
            Name = name;
            Url = url;
            IsActive = isActive;
            IconClassName = iconClassName;
        }

        public string Name { get; }
        public string Url { get; }
        public bool IsActive { get; set; }
        public string IconClassName { get; }
    }
}
