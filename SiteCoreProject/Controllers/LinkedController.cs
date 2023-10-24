using System.Web.Mvc;
using SiteCoreProject.Interfaces;

namespace SiteCoreProject.Controllers
{
    public class LinkedController : Controller
    {
        private readonly IHeaderService _headerService;
        private readonly ITopNavigationService _topNavigationService;
        private readonly IFooterService _footerService;

        // GET: Linked
        public LinkedController(IHeaderService headerService, ITopNavigationService topNavigationService, IFooterService footerService)
        {
            _headerService = headerService;
            _topNavigationService = topNavigationService;
            _footerService = footerService;
        }

        public ActionResult Header()
        {
            var header = _headerService.GetHeaderData();

            return View(header);
        }

        public ActionResult TopNavigation()
        {
            var topNavigation = _topNavigationService.HeaderNavigation();

            return View(topNavigation);
        }

        public ActionResult Footer()
        {
            var footer = _footerService.GetFooterData();

            return View(footer);
        }

    }
}