using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Conrate
{
    public class LayoutItem
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public int LayoutId { get; set; }
        public virtual Layout Layout { get; set; }
    }
}
