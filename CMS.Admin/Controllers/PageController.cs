using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                model.Pages = context.Pages.Include("Layout").Where(x => x.IsDeleted == false).ToList();
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
        public ActionResult Add(string Name, string[] txtArealar, int layoutId)
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
                

                if (context.SaveChanges() > 0)
                {
                    var sonEklenen = context.Pages.Where(x => x.Name == Name).FirstOrDefault();

                    foreach (var icerik in txtArealar)
                    {
                        context.PageContents.Add(new PageContent()
                        {
                            Content = icerik,
                            PageId = sonEklenen.Id
                        });
                    }

                    return context.SaveChanges() > 0 ? RedirectToAction("Index") : null;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Update(string Name, Array txtArealar, int layoutId)
        {
            
            

            
            return View();
        }



        ////////////////////////////////////////////////////////////////////////////// Custom Metod

        public string GenerateSlug(string phrase, int maxLength = 50)
        {
            string str = phrase.ToLower();
            str = str.Replace('ı', 'i');
            str = str.Replace('ü', 'u');
            str = str.Replace('ö', 'o');
            str = str.Replace('ç', 'c');
            str = str.Replace('ğ', 'g');
            str = str.Replace('ş', 's');
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