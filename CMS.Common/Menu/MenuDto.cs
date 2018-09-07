using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.General;
using CMS.Common.Layout;

namespace CMS.Common.Menu
{
    public class MenuDto : BaseDto
    {
        public MenuDto()
        {
            this.Pages = new List<PageDto>();
        }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public string Icon { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<PageDto> Pages { get; set; }
        public IEnumerable<MenuDto> Menus { get; set; }

    }
}
