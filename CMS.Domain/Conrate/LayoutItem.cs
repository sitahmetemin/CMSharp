using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Abstract;

namespace CMS.Domain.Conrate
{
    public class LayoutItem : BaseEntitiy
    {

        public string Class { get; set; }
        public int LayoutId { get; set; }
        public virtual Layout Layout { get; set; }
    }
}
