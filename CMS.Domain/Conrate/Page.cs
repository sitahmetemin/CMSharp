using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Abstract;

namespace CMS.Domain.Conrate
{
    public class Page :BaseEntitiy
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? LayoutId { get; set; }
        public int? MenuId { get; set; }
        public virtual Layout Layout { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual List<PageContent> PageContents { get; set; }
    }
}
