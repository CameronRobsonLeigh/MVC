using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreProject.Models
{
    public class CardModel
    {
        public IHtmlString Image { get; set; }

        public IHtmlString TextCTA { get; set; }

        public IHtmlString Title { get; set; }
    }
}