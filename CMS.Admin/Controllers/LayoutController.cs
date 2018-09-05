using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Admin.Models;
using CMS.DataAccsess.Concrate;
using CMS.DataAccsess.Services;
using CMS.Domain.Conrate;

namespace CMS.Admin.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            var model = Services.LayoutService.GetLayouts();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string Name, Array kolonlar)
        {
            Services.LayoutService.InsertNewLayout(Name, kolonlar);
            return RedirectToAction("Index");
        }

        public ActionResult Update(string layoutName)
        {
            using (CMSContext context = new CMSContext())
            {
                LayoutModel model = new LayoutModel();

                ViewBag.layout = context.Layouts.Include("LayoutItems").SingleOrDefault(x => x.Name == layoutName);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(string oldLayout, string Name, Array kolonlar)
        {
            Services.LayoutService.UpdateLayout(oldLayout, Name, kolonlar);


            return RedirectToAction("Index");
        }

        public ActionResult Delete(string layoutName)
        {
            Services.LayoutService.DeleteLayout(layoutName);
            return RedirectToAction("Index");
        }
    }
}