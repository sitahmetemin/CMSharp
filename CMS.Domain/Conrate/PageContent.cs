using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Conrate
{
    public class PageContent
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? PageId { get; set; }
        public Page Page { get; set; }
    }
}
