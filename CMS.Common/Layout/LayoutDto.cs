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
        public IEnumerable<LItemDto> Items { get; set; }
    }

    public class LItemDto : BaseDto
    {
        public LItemDto()
        {
            Sizes = new List<ParameterDto>()
            {
                new ParameterDto {Name = "Medium", Value = "col-md"},
                new ParameterDto {Name = "Large", Value = "col-lg"}
            };
        }

        public IEnumerable<ParameterDto> Sizes { get; set; }
        public int SelectedColumn { get; set; }
        public string SizeValue { get; set; }

        public string Size
        {
            get { return string.Format("{0}-{1}", this.SizeValue, this.SelectedColumn); }
        }
    }
}