using System.Collections.Generic;

namespace SiteCoreProject.Models
{
    public class TopNavigationModel
    {
        public List<Navigations> TopNavigation { get; set; }

        public List<MainNavigationModel> MainNavigation { get; set; }
    }
}