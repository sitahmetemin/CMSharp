﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Abstract;

namespace CMS.Domain.Conrate
{
    public class Menu: BaseEntitiy
    {
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int OrderNo { get; set; }
        public string Icon { get; set; }
        public virtual Menu ParentMenu { get; set; }
        public virtual List<Menu> Menus { get; set; }
        public virtual ICollection<Page> Page { get; set; }
    }
}
