using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Abstract;

namespace CMS.Domain.Conrate
{
    public class PageContent : BaseEntitiy
    {
        public string Content { get; set; }
        public int? PageId { get; set; }
        public Page Page { get; set; }
    }
}
