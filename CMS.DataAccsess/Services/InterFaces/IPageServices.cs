using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Layout;

namespace CMS.DataAccsess.Services.InterFaces
{
    public interface IPageServices
    {

        IEnumerable<PageDto> GetPages();

        PageDto GetPageByName(string Name);

        void InsertNewPage(string Name, Array Columns, int LayoutID, int MenuId, string[] Class);
        void UpdatePage(string oldName, string Name, Array Columns, int LayoutID);
        void DeletePage(string Name);
    }
}
