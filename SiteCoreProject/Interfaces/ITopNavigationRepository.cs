using System;
using SiteCoreProject.Models;
using System.Collections.Generic;

namespace SiteCoreProject.Interfaces
{
    public interface ITopNavigationRepository
    {
        List<Navigations> GetNavigationObject(Guid navigationFolder);
    }
}
