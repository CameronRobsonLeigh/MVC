using System;
using System.Collections.Generic;
using System.Web;

namespace SiteCoreProject.Interfaces
{
    public interface IMainRepository
    {
        IHtmlString ConvertHtmlString(string value);

        IHtmlString GetRenderField(string field);

        IHtmlString GetRenderField(Guid id, string field);

        IEnumerable<Guid> GetFolderElements(Guid field);

        //IEnumerable<Guid> GetChildItems(string field);


    }
}
