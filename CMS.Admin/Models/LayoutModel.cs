using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Domain.Conrate;

namespace CMS.Admin.Models
{
    public class LayoutModel
    {
        public virtual ICollection<Layout> Layouts { get; set; }
    }
}