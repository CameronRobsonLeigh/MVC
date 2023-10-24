using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreProject.Models
{
    public class SubNavigationItem : Navigations
    {
        public List<Navigations> ChildItems { get; set; } = new List<Navigations>();

    }
}