using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.General;

namespace CMS.Common.Layout
{
    public class PageDto : BaseDto
    {
        public PageDto()
        {
            this.PageContents = new List<PageContentDto>();
        }

        public string Name { get; set; }
        public IEnumerable<PageContentDto> PageContents { get; set; }
        public int? LayoutId { get; set; }
        public string LayoutName { get; set; }
    }

    public class PageContentDto : BaseDto
    {
        public string Content { get; set; }
        public int? PageId { get; set; }
        public string Class { get; set; }
    }
}
