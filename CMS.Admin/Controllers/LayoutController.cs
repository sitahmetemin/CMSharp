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
                //Layout Güncelleme İşlemi
                var layoutBilgiler = context.Layouts.FirstOrDefault(c => c.Name == oldLayout);
                layoutBilgiler.Name = Name;
                context.Layouts.AddOrUpdate(layoutBilgiler);

                //Layout İtemlerini silme işlemi
                var eskilayoutKolonlar = context.LayoutItems.Where(x => x.LayoutId == layoutBilgiler.Id).ToList();
                context.LayoutItems.RemoveRange(eskilayoutKolonlar);
                if (context.SaveChanges() > 0)
                {
                    //Layout İtemleri ekleme işlemi
                    foreach (var kolonBilgisi in kolonlar)
                    {
                        var post = new LayoutItem {Class = kolonBilgisi.ToString(), LayoutId = layoutBilgiler.Id,};
                        context.LayoutItems.AddOrUpdate(post);
                    }

                    //Veri tabanına kayıt işlemi
                    if (context.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
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

                return context.SaveChanges() > 0 ? RedirectToAction("Index") : null;
            }
        }
    }
}