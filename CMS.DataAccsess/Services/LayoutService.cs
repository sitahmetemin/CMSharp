using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Layout;
using CMS.DataAccsess.Services.InterFaces;

namespace CMS.DataAccsess.Services
{
    public class LayoutService : BaseService,ILayoutService
    {
        public IEnumerable<LayoutDto> GetLayouts()
        {
            throw new NotImplementedException();
        }

        public LayoutDto GetLayoutById(int Id)
        {
            throw new NotImplementedException();
        }

        public void InsertNewLayout(LayoutDto model)
        {
            throw new NotImplementedException();
        }
    }
}
