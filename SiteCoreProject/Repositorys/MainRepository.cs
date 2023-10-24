using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using SiteCoreProject.Interfaces;

namespace SiteCoreProject.Repositorys
{
    public class MainRepository : IMainRepository
    {
        private Item GetCurrentRenderingItem => RenderingContext.Current.Rendering.Item;

        public IHtmlString ConvertHtmlString(string value)
        {
            return new HtmlString(value);
        }

        public IHtmlString GetRenderField(string field)
        {
            return new HtmlString(FieldRenderer.Render(GetCurrentRenderingItem, field));
        }

        public IHtmlString GetRenderField(Guid id, string field)
        {
            return new HtmlString(FieldRenderer.Render(GetItemById(id), field));
        }

        public IEnumerable<Guid> GetFolderElements(Guid folder)
        {
            var getNavigationFolder = Sitecore.Context.Database.Items.GetItem(new ID(folder));
            var listItems = getNavigationFolder.GetChildren();
            return listItems.Select(x => x.ID.Guid);
        }

        private Item GetItemById(Guid id)
        {
            return Sitecore.Context.Database.Items.GetItem(new ID(id));
        }

        public IEnumerable<Guid> GetChildItems(Guid parentId)
        {
            return GetItemById(parentId).Children?.Select(x => x.ID.Guid);
        }
    }
}