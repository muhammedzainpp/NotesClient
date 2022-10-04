using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Notes.Web.Views.Components.SidebarComponents;

public partial class Sidebar
{
    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    public List<SideBarItem> Items { get; set; } = new();

    protected override void OnInitialized()
    {
        Navigation.LocationChanged += OnLocationChanged;

        AddToList("Notes", "", true, "bx bx-bulb");

        AddToList("Labels", "labels", false, "bx bx-tag-alt");
    }

    private void AddToList(string name, string url, bool isActive, string iconClassName)
    {
        var item = new SideBarItem(name, url, isActive, iconClassName);
        Items.Add(item);
    }

    private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        var currentUrl = Navigation.ToBaseRelativePath(Navigation.Uri).ToLower();

        Items.ForEach(item => item.IsActive = item.Url == currentUrl);

        StateHasChanged();
    }

    public class SideBarItem
    {
        public SideBarItem(string name, string url, bool isActive, string iconClassName)
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
