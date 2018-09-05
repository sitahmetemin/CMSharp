using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Abstract;

namespace CMS.Domain.Conrate
{
    public class Layout :BaseEntitiy
    {
        public string Name { get; set; }

        public  ICollection<Page> Pages { get; set; }
        public virtual ICollection<LayoutItem> LayoutItems { get; set; }
    }
}
