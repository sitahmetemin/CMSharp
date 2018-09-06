using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CMS.DataAccsess.Services;

namespace CMS.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            var model = Services.MenuService.GetMenus();
            return View(model);
        }

        public ActionResult Add()
        {
            var model = Services.MenuService.GetMenus();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(string Name, int parentId, string icon)
        {
            Services.MenuService.InsertNewMenu(Name, parentId, icon);
            return View();
        }
    }
}