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

        LayoutDto GetLayoutByName(string Name);

        void InsertNewLayout(string Name, Array Kolonlar);
        void UpdateLayout(string oldName , string Name, Array Columns);
        void DeleteLayout(string Name);
    }
}
