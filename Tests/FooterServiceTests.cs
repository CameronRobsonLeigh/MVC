using Moq;
using NUnit.Framework;
using SiteCoreProject.Fields;
using SiteCoreProject.Interfaces;
using SiteCoreProject.Models;
using SiteCoreProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using SiteCoreProject.Repositorys;

namespace Tests
{
    [TestFixture]
    public class FooterServiceTests
    {
        private IFooterService _footerService;
        private IMainRepository _mainRepo;
        private Mock<IMainRepository> _repository;
        private Mock<IFooterService> _footerServ;

        [Test]
        public void Service_GetFooterLogo_ReturnsText()
        {
            var logoText = new HtmlString("colt");
            _repository.Setup(s => s.GetRenderField(FooterFields.FooterTitle)).Returns(logoText);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.LogoText);
            Assert.AreEqual(logoText, model.LogoText);
        }

        [Test]
        public void Service_GetQuickLinksTitle_ReturnsText()
        {
            var linkHeader = new HtmlString("Quick links");
            _repository.Setup(s => s.GetRenderField(FooterFields.QuickLinksTitle)).Returns(linkHeader);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.QuickLinksTitle);
            Assert.AreEqual(linkHeader, model.QuickLinksTitle);
        }

        [Test]
        public void Service_GetQuickLinksNavigationList_ReturnsList()
        {
            List<BasicNavigations> quickLinksNavList = new List<BasicNavigations>();
            Guid guid = new Guid("{2A2EEA1E-4F92-454D-BE0F-2171F4B47A4A}");
            quickLinksNavList.Add(_footerService.GetTitles(guid));


            _footerServ.Setup(s => s.GetQuickLinks(SitecoreItemReferencesFields.QuickLinksFolder)).Returns(quickLinksNavList);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.QuickLinksNavigationsList);
            Assert.AreEqual(quickLinksNavList, model.QuickLinksNavigationsList);
        }

        public List<BasicNavigations> GetQuickLinks(Guid field)
        {
            var children = _mainRepo.GetFolderElements(field);
            var getChildren = children.Select(c => GetTitles(c)).ToList();

            return getChildren;
        }

        private BasicNavigations GetTitles(Guid guid)
        {
            return new BasicNavigations
            {
                Title = _mainRepo.GetRenderField(guid, Fields.BasicTitle),
                Link = _mainRepo.GetRenderField(guid, Fields.BasicLink)
            };
        }

        [Test]
        public void Service_DataCentresTitle_ReturnsText()
        {
            var linkHeader = new HtmlString("Data Centres");
            _repository.Setup(s => s.GetRenderField(FooterFields.DataCentresTitle)).Returns(linkHeader);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.DataCentresTitle);
            Assert.AreEqual(linkHeader, model.DataCentresTitle);
        }

        [Test]
        public void Service_GetDataCentresNavigationList_ReturnsList()
        {
            List<BasicNavigations> dataCentresNavList = new List<BasicNavigations>();
            Guid guid = new Guid("{DEA4E294-6907-4A6F-BCAC-0BCA82862AAF}");
            dataCentresNavList.Add(_footerService.GetTitles(guid));
    

            _footerServ.Setup(s => s.GetQuickLinks(SitecoreItemReferencesFields.DataCentresFolder)).Returns(dataCentresNavList);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.DataCentresNavigationsList);
            Assert.AreEqual(dataCentresNavList, model.DataCentresNavigationsList);
        }

        [Test]
        public void Service_GetSocialMediaList_ReturnsList()
        {
            List<SocialMediaModel> socialMediaList = new List<SocialMediaModel>();
            socialMediaList.Add(
                new SocialMediaModel { Icon = ConvertHtmlString("/Project/facebook"), Link = ConvertHtmlString("https://www.facebook.com") }
                );

            _footerServ.Setup(s => s.GetSocials(SitecoreItemReferencesFields.SocialMediaFolder)).Returns(socialMediaList);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.SocialMediaList);
            Assert.AreEqual(socialMediaList, model.SocialMediaList);
        }

        [Test]
        public void Service_CopyRightHeader_ReturnsText()
        {
            var copyRightHeader = new HtmlString("© 2017 Colt Technology Services Group Ltd");
            _repository.Setup(s => s.GetRenderField(FooterFields.CopyRightText)).Returns(copyRightHeader);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.CopyRightText);
            Assert.AreEqual(copyRightHeader, model.CopyRightText);
        }

        [Test]
        public void Service_ContactSalesHeader_ReturnsText()
        {
            var contactSalesLabel = new HtmlString("Contact Sales");
            _repository.Setup(s => s.GetRenderField(FooterFields.ContactSalesLabel)).Returns(contactSalesLabel);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.ContactSalesLabel);
            Assert.AreEqual(contactSalesLabel, model.ContactSalesLabel);
        }

        [Test]
        public void Service_ContactSalesNumber_ReturnsText()
        {
            var contactSalesNumber = new HtmlString("+44 (0) 20 7390 3158");
            _repository.Setup(s => s.GetRenderField(FooterFields.ContactSalesNumber)).Returns(contactSalesNumber);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.ContactSalesNumber);
            Assert.AreEqual(contactSalesNumber, model.ContactSalesNumber);
        }

        [Test]
        public void Service_ContactSupportHeader_ReturnsText()
        {
            var contactSupportLabel = new HtmlString("Contact Support");
            _repository.Setup(s => s.GetRenderField(FooterFields.ContactSupportLabel)).Returns(contactSupportLabel);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.ContactSupportLabel);
            Assert.AreEqual(contactSupportLabel, model.ContactSupportLabel);
        }

        [Test]
        public void Service_ContactSupportNumber_ReturnsText()
        {
            var contactSupportNumber = new HtmlString("+44 (0) 20 7390 3158");
            _repository.Setup(s => s.GetRenderField(FooterFields.ContactSupportNumber)).Returns(contactSupportNumber);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.ContactSupportNumber);
            Assert.AreEqual(contactSupportNumber, model.ContactSupportNumber);
        }

        [Test]
        public void Service_EmailLabel_ReturnsText()
        {
            var emailLabel = new HtmlString("Email");
            _repository.Setup(s => s.GetRenderField(FooterFields.EmailLabel)).Returns(emailLabel);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.EmailLabel);
            Assert.AreEqual(emailLabel, model.EmailLabel);
        }

        [Test]
        public void Service_EmailAddress_ReturnsText()
        {
            var emailAddress = new HtmlString("dcsinfo@colt.net");
            _repository.Setup(s => s.GetRenderField(FooterFields.EmailAddress)).Returns(emailAddress);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.EmailAddress);
            Assert.AreEqual(emailAddress, model.EmailAddress);
        }

        [Test]
        public void Service_KeyLocationsHeader_ReturnsText()
        {
            var keyLocationsHeader = new HtmlString("Key Locations");
            _repository.Setup(s => s.GetRenderField(FooterFields.KeyLocationsTitle)).Returns(keyLocationsHeader);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.KeyLocationsTitle);
            Assert.AreEqual(keyLocationsHeader, model.KeyLocationsTitle);
        }

        [Test]
        public void Service_GetKeyLocations_ReturnsList()
        {
            List<BasicNavigations> locationList = new List<BasicNavigations>();
            Guid guid = new Guid("{8F66AF89-BF2B-4B89-96F1-EF45FE817B28}");
            locationList.Add(_footerService.GetTitles(guid));

            _footerServ.Setup(s => s.GetQuickLinks(SitecoreItemReferencesFields.KeyLocationsFolder)).Returns(locationList);
            var model = _footerService.GetFooterData();

            Assert.IsNotNull(model.KeyLocationsNavigationsList);
            Assert.AreEqual(locationList, model.KeyLocationsNavigationsList);
        }

        private BasicNavigations GetDataCentresTest(Guid guid)
        {
            return new BasicNavigations()
            {
                Title = ConvertHtmlString("Asia"),
                Link = ConvertHtmlString("/Home/HomePage")
            };
        }

        public IHtmlString GetRenderField(Guid id, string field)
        {
            return new HtmlString(FieldRenderer.Render(GetItemById(id), field));
        }

        private Item GetItemById(Guid id)
        {
            return Sitecore.Context.Database.Items.GetItem(new ID(id));
        }


        public IHtmlString ConvertHtmlString(string value)
        {
            return new HtmlString(value);
        }

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IMainRepository>();
            _mainRepo = new MainRepository();
            _footerService = new FooterService(_mainRepo);
            _footerServ = new Mock<IFooterService>();
        }
    }
}
