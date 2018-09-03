using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        [HttpGet]
        public JsonResult LayoutCagir(int cagrilacakLayout)
        {
            CMSContext context = new CMSContext();
            var bilgiler = context.LayoutItems.Where(x => x.LayoutId == cagrilacakLayout).Select(a => a.Class).ToList();

            
            return Json(bilgiler,JsonRequestBehavior.AllowGet);
        }

        //////////////////////////////////////////////////////////////////// Post
        [HttpPost]
        public ActionResult Add(string veriler)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(string Name, Array txtArealar, int layoutId)
        {
            
            using (CMSContext context = new CMSContext())
            {
                context.Pages.Add(new Page()
                {
                    Name = Name,
                    LayoutId = layoutId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false,
                    Slug = GenerateSlug(Name)
                });
                
            }

            
            return View();
        }

        public string GenerateSlug(string phrase, int maxLength = 50)
        {
            string str = phrase.ToLower();
            // invalid chars, make into spaces
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces/hyphens into one space       
            str = Regex.Replace(str, @"[\s-]+", " ").Trim();
            // cut and trim it
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
            // hyphens
            str = Regex.Replace(str, @"\s", "-");

            return str;
        }
    }
}