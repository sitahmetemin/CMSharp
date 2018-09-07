using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Common.Layout;
using CMS.Common.Menu;
using CMS.Domain.Conrate;

namespace CMS.Admin.Models
{
    public class PageViewModel
    {
        public virtual IEnumerable<Page> PageDtos { get; set; }
        public virtual IEnumerable<Menu> MenuDto { get; set; }
    }
}