using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Layout;

namespace CMS.DataAccsess.Services.InterFaces
{
    public interface ILayoutService
    {
        IEnumerable<LayoutDto> GetLayouts();

        LayoutDto GetLayoutById(int Id);

        void InsertNewLayout(LayoutDto model);
        void UpdateLayout(LayoutDto model);
        void DeleteLayout(LayoutDto model);
    }
}
