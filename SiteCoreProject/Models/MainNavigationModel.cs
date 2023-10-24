using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreProject.Models
{
    public class MainNavigationModel : Navigations
    {
        public CardModel Card { get; set; }

        public List<SubNavigationItem> ChildItems { get; set; } = new List<SubNavigationItem>();
    }
}