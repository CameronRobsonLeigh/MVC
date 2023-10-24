using System.Web.Mvc;

namespace SiteCoreProject.Controllers
{
    public class Ignore : Controller
    {
        public ActionResult Index()
        {
            //var model = new NavigationModel();
            //List<NavigationModel> navigations = new List<NavigationModel>();
            //var homeItem = Sitecore.Context.Site.HomeItem(); // grab home item

            //if (homeItem.HasChildren) // get children under home nav and build navigations
            //{
            //    foreach (Item childItem in homeItem.Children) // loop through children
            //    {
            //        navigations.Add(BuildNavigation(childItem)); // add each child to navigations list
            //    }
            //}
            //model.Navigations = navigations; // pass our list to our navigation model

            //return View(model);
            return View();
        }

        //private NavigationModel BuildNavigation(Item item) // method and takes tree hierarchy items as parameters
        //{
        //    MediaItem imageItem = Sitecore.Context.Database.GetItem(Fields.Fields.ImageId);
        //    var getMediaId = MediaManager.GetMediaUrl(imageItem);
   
        //    return new NavigationModel // add each to the list
        //    {
        //        //NavigationTitle = item.Fields["Title"]?.Value,
        //        //NavigationLink = item.Url(),
        //        //ActiveClass = PageContext.Current.Item.ID == item.ID ? "active" : string.Empty,
        //        //ImageUrl = getMediaId
        //    };
        //}
    }
}
