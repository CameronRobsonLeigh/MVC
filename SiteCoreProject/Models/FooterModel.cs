using System.Collections.Generic;
using System.Web;

namespace SiteCoreProject.Models
{
    public class FooterModel 
    {
        public IHtmlString LogoText { get; set; }

        public IHtmlString QuickLinksTitle { get; set; }

        public List<BasicNavigations> QuickLinksNavigationsList { get; set; }

        public IHtmlString DataCentresTitle { get; set; }

        public List<BasicNavigations> DataCentresNavigationsList { get; set; }

        public List<SocialMediaModel> SocialMediaList { get; set; }

        public IHtmlString CopyRightText { get; set; }

        public IHtmlString ContactSalesLabel { get; set; }

        public IHtmlString ContactSalesNumber { get; set; }

        public IHtmlString ContactSupportLabel { get; set; }

        public IHtmlString ContactSupportNumber { get; set; }

        public IHtmlString EmailLabel { get; set; }

        public IHtmlString EmailAddress { get; set; }

        public IHtmlString KeyLocationsTitle { get; set; }

        public List<BasicNavigations> KeyLocationsNavigationsList { get; set; }
    }
}