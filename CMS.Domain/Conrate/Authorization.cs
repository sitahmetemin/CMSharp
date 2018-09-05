using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Abstract;

namespace CMS.Domain.Conrate
{
    public class Authorization : BaseEntitiy
    {
        public string Authority { get; set; }

        public ICollection<Users> Userses { get; set; }
    }
}
