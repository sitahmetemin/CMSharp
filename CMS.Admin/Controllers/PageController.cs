using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CMS.Admin.Models;
using CMS.DataAccsess.Concrate;
using CMS.DataAccsess.Services;
using CMS.Domain.Conrate;

namespace CMS.Admin.Controllers
{
    public class PageController : Controller
    {
        /////////////////////////////////////////////////////////////////// GET: Page
        public ActionResult Index()
        {

            var model = Services.PageServices.GetPages();
            return View(model);
            //LayoutModel model = new LayoutModel();
            //using (CMSContext context = new CMSContext())
            //{
            //    model.Pages = context.Pages.Include("Layout").Where(x => x.IsDeleted == false).ToList();
            //    return View(model);
            //}
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = Services.LayoutService.GetLayouts();
            ViewBag.menulist = Services.MenuService.GetMenus();
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(string pageName)
        {
            using (CMSContext context = new CMSContext())
            {
                LayoutModel model = new LayoutModel();

                model.Layouts = context.Layouts.Where(x => x.IsDeleted == false).ToList();
                model.Pages = context.Pages.Include("PageContents").Where(z => z.Name == pageName).ToList();
                //model.Pages = context.Pages.Include("PageContent").Where(x => x.Name == pageName).ToList();

                return View(model);
            }
            
        }

        [HttpGet]
        public ActionResult Delete(string pageName)
        {
            using (CMSContext ctx = new CMSContext())
            {
                var page = ctx.Pages.Where(x => x.Name == pageName).FirstOrDefault();
                page.IsDeleted = true;
                return ctx.SaveChanges() > 0 ? RedirectToAction("Index") : null;
            }
        }

        [HttpGet]
        public JsonResult LayoutCagir(int cagrilacakLayout)
        {
            CMSContext context = new CMSContext();
            var bilgiler = context.LayoutItems.Where(x => x.LayoutId == cagrilacakLayout).Select(a => a.Class).ToList();

            
            return Json(bilgiler,JsonRequestBehavior.AllowGet);
        }

        //////////////////////////////////////////////////////////////////// Post
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string Name, string[] txtArealar, int layoutId, int menuId, string[] Classes)
        {
            Services.PageServices.InsertNewPage(Name,txtArealar,layoutId, menuId, Classes);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(string Name, Array txtArealar, int layoutId)
        {
            
            

            
            return View();
        }



        ////////////////////////////////////////////////////////////////////////////// Custom Metod

        
    }
}