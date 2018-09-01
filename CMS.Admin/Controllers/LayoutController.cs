using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Admin.Models;
using CMS.DataAccsess.Concrate;
using CMS.Domain.Conrate;

namespace CMS.Admin.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            //var model = Services.
            LayoutModel model = new LayoutModel();
            using (CMSContext context = new CMSContext())
            {
                model.Layouts = context.Layouts.Where(x => x.IsDeleted == false).ToList();
                return View(model);
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string Name, Array kolonlar)
        {
            using (CMSContext context = new CMSContext())
            {
                context.Layouts.Add(new Layout()
                {
                    Name = Name,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                });
                if (context.SaveChanges() > 0)
                {
                    var layoutItem = context.Layouts.OrderByDescending(x => x.Id).FirstOrDefault();

                    foreach (var kolonBilgisi in kolonlar)
                    {
                        var post = new LayoutItem {Class = kolonBilgisi.ToString(), LayoutId = layoutItem.Id,};
                        context.LayoutItems.Add(post);
                    }

                    if (context.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return null;
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
            using (CMSContext context = new CMSContext())
            {
                var layoutBilgiler = context.Layouts.Where(c => c.Name == oldLayout).FirstOrDefault();
                layoutBilgiler.Name = Name;


                var layout = context.Layouts.OrderByDescending(x => x.Id).FirstOrDefault();
                //TODO: Burada KALDIN !!
                context.LayoutItems.Remove(layout.LayoutItems);
                foreach (var kolonBilgisi in kolonlar)
                {
                    var post = new LayoutItem {Class = kolonBilgisi.ToString(), LayoutId = layout.Id,};
                    context.LayoutItems.AddOrUpdate(post);
                }

                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return null;
        }

        public ActionResult Delete(string layoutName)
        {
            using (CMSContext context = new CMSContext())
            {
                var layout = context.Layouts.Where(c => c.Name == layoutName).FirstOrDefault();
                layout.IsDeleted = true;
                context.Layouts.AddOrUpdate(layout);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return null;
        }
    }
}