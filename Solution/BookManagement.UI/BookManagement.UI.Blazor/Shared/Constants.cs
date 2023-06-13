namespace BookManagement.UI.Blazor.Shared
{
	public static class Constants
	{
		public static List<NavItem> SidebarItems { get; } = new List<NavItem>
	{
		new NavItem { Link = "/", Title = "Home" },
		new NavItem { Link = "/products", Title = "Products" },
		new NavItem { Link = "/about", Title = "About" }
	};
	}

	public class NavItem
	{
		public string Link { get; set; }
		public string Title { get; set; }
	}

}
