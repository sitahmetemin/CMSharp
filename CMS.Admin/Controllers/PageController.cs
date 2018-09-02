using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Admin.Models;
using CMS.DataAccsess.Concrate;
using CMS.Domain.Conrate;

namespace CMS.Admin.Controllers
{
    public class PageController : Controller
    {
        /////////////////////////////////////////////////////////////////// GET: Page
        public ActionResult Index()
        {
            LayoutModel model = new LayoutModel();
            using (CMSContext context = new CMSContext())
            {
                model.Pages = context.Pages.Where(x => x.IsDeleted == false).ToList();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            LayoutModel model = new LayoutModel();
            using (CMSContext context = new CMSContext())
            {
                model.Layouts = context.Layouts.Where(x => x.IsDeleted == false).ToList();
                return View(model);
            }

            return null;
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string slug)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult LayoutCagir(int cagrilacakLayout)
        {
            CMSContext context = new CMSContext();
            List<LayoutItem> bilgiler = new List<LayoutItem>();
            bilgiler = context.LayoutItems.Where(x => x.LayoutId == cagrilacakLayout).ToList();
            return Json(bilgiler, JsonRequestBehavior.AllowGet);
        }

        //////////////////////////////////////////////////////////////////// Post
        [HttpPost]
        public ActionResult Add(string veriler)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(string veriler)
        {
            return View();
        }
    }
}