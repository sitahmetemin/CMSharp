﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DataAccsess.Services.InterFaces;

namespace CMS.DataAccsess.Services
{
    public class Services
    {
        public static ILayoutService LayoutService
        {
            get
            {
                //TODO : Injection yapılacak
                return (ILayoutService) new LayoutService();
            }
        }

        public static IPageServices PageServices
        {
            get { return (IPageServices) new PageService(); }
        }

        public static IMenuService MenuService
        {
            get { return (IMenuService)new MenuService(); }
        }
    }
}
