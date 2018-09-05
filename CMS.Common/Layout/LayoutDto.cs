using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.General;

namespace CMS.Common.Layout
{
    public class LayoutDto : BaseDto
    {
        public LayoutDto()
        {
            this.Items = new List<LItemDto>();
        }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<LItemDto> Items { get; set; }
    }

    public class LItemDto : BaseDto
    {
        public string Class { get; set; }
        
    }
}