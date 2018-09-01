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
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LayoutId { get; set; }
        public virtual Layout Layout { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<PageContent> PageContents { get; set; }
    }
}
