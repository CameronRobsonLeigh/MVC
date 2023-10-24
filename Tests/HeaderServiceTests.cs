using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SiteCoreProject.Fields;
using SiteCoreProject.Interfaces;
using SiteCoreProject.Models;
using SiteCoreProject.Services;
using System.Web;

namespace Tests
{
    [TestFixture]
    public class HeaderServiceTests
    {
        private IHeaderService _headerService;
        private ITopNavigationService _topNavigationService;
        private Mock<IMainRepository> _repository;
        private Mock<ITopNavigationRepository> _topNavigationRepository;

        [Test]
        public void Service_GetHeader_LogoText_ReturnsData()
        {
            var logoText = new HtmlString("colt");
            _repository.Setup(s => s.GetRenderField(HeaderFields.Title)).Returns(logoText);
            var model = _headerService.GetHeaderData();

            Assert.IsNotNull(model.LogoText);
            Assert.AreEqual(logoText, model.LogoText);
        }

        [Test]
        public void Service_TopNavigation_ReturnsData()
        {
            List<Navigations> navigations = new List<Navigations>();
            navigations.Add(BuildNavigation());

            _topNavigationRepository.Setup(s => s.GetNavigationObject(SitecoreItemReferencesFields.NavigationElement)).Returns(navigations);
            var model = _topNavigationService.HeaderNavigation();

            Assert.IsNotNull(model.TopNavigation);
            Assert.AreEqual(model.TopNavigation, model.TopNavigation);
        }


        public Navigations BuildNavigation()
        {
            return new Navigations
            {
                Title = ConvertHtmlString("Solutions"),
                Link = ConvertHtmlString("HomePage")
            };
        }

        public IHtmlString ConvertHtmlString(string value)
        {
            return new HtmlString(value);
        }


        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IMainRepository>();
            _topNavigationRepository = new Mock<ITopNavigationRepository>();
            _headerService = new HeaderService(_repository.Object);
            _topNavigationService = new TopNavigationService(_topNavigationRepository.Object);
        }
    }
}
