using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CMS.Common.Menu;
using CMS.DataAccsess.Services;

namespace CMS.Admin.Controllers
{
    public class MenuController : Controller
    {
        ////////////////////////////////////////////////////////////////////////////////////////GET: Menu
        public ActionResult Index()
        {
            var model = Services.MenuService.GetMenus();
            var parentModel = model.Where(x => x.ParentId == null).ToList();
            
            List<MenuDto> menu = new List<MenuDto>();
            foreach (var parent in parentModel)
            {
                menu.Add(parent);
                var childModel = model.Where(x => x.ParentId == parent.Id).ToList();
                foreach (var child in childModel)
                {
                    menu.Add(child);
                    var subchildModel = model.Where(x => x.ParentId == child.Id).ToList();
                    foreach (var subchild in subchildModel)
                    {
                        menu.Add(subchild);
                    }
                }
            }

            return View(menu);
        }

        //private static int ChildQuery(int Id)
        //{

        //    return null;
        //}

        public ActionResult Add()
        {
            var model = Services.MenuService.GetMenus();
            return View(model);
        }

        public ActionResult Delete(string MenuName)
        {
            Services.MenuService.DeleteMenu(MenuName);
            return RedirectToAction("Index");
        }

        public ActionResult Update(string MenuName)
        {
            var bilgiler = Services.MenuService.GetMenuByName(MenuName);
            if (bilgiler.Name != null)
            {
                ViewBag.Name = bilgiler.Name;
            }

            if (bilgiler.ParentId != null)
            {
                ViewBag.ParentId = bilgiler.ParentId;
            }

            if (bilgiler.Icon != null)
            {
                ViewBag.Icon = bilgiler.Icon;
            }

            var model = Services.MenuService.GetMenus();

            return View(model);
        }

        ////////////////////////////////////////////////////////////////////////////////////////Postlar
        [HttpPost]
        public ActionResult Add(string Name, int? parentId, string icon)
        {
            Services.MenuService.InsertNewMenu(Name, parentId, icon);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(string Name, int? parentId, string icon, string oldName)
        {
            Services.MenuService.UpdateMenu(Name, parentId, icon, oldName);
            return RedirectToAction("Index");
        }
    }
}