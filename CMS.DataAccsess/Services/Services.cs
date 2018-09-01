using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DataAccsess.Services.InterFaces;

namespace CMS.DataAccsess.Services
{
    public class Services
    {
        public static ILayoutService LayoutService
        {
            get { return (ILayoutService) new LayoutService(); }
        }
    }
}
