using System;
using System.Collections.Generic;
using SiteCoreProject.Models;

namespace SiteCoreProject.Interfaces
{
    public interface IFooterService
    {
        FooterModel GetFooterData();

        List<BasicNavigations> GetQuickLinks(Guid folder);

        BasicNavigations GetTitles(Guid guid);

        SocialMediaModel GetImageAndLink(Guid guid);

        List<SocialMediaModel> GetSocials(Guid folder);


    }
}
