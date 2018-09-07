using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Abstract;

namespace CMS.Domain.Conrate
{
    public class SliderContext:BaseEntitiy
    {
        public string imgWay { get; set; }
        public int Slider_Id { get; set; }
        public virtual Slider Slider { get; set; }
    }
}
