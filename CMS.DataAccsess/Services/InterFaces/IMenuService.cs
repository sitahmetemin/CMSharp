﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Menu;

namespace CMS.DataAccsess.Services.InterFaces
{
    public interface IMenuService
    {
        IEnumerable<MenuDto> GetMenus();
        MenuDto GetMenuByName(string Name);
        void InsertNewMenu(string Name, int? ParentId, string icon);
        void UpdateMenu(string Name, int? ParentId, string icon, string oldName);
        void DeleteMenu(string Name);
        string GetMenuRecursion();
    }
}
