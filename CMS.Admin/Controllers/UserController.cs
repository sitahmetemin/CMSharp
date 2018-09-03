using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.DataAccsess.Concrate;

namespace CMS.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (CMSContext _context = new CMSContext())
            {
                var kullanici = _context.Userses.Include("Authorization").FirstOrDefault(x => x.Id == 1);
                TempData.Add("DisplayName" , kullanici.DisplayName);
                TempData.Add("FirstName", kullanici.FirstName);
                TempData.Add("LastName", kullanici.LastName);
                TempData.Add("Email", kullanici.Email);
                TempData.Add("Image", kullanici.Image);
                TempData.Add("Password", kullanici.Password);
            }
            
            return View();
        }

        [HttpPost]
        public JsonResult Index(string Email, string DisplayName, string FirstName, string LastName, string Password, string Image)
        {
            using (CMSContext _context = new CMSContext())
            {

                var kisi = _context.Userses.FirstOrDefault(x => x.Id == 1);
                kisi.Email = Email;
                kisi.DisplayName = DisplayName;
                kisi.FirstName = FirstName;
                kisi.LastName = LastName;
                kisi.Password = Password;
                kisi.Image = Image;

                _context.Userses.AddOrUpdate(kisi);
                return _context.SaveChanges() > 0 ?  Json("success", JsonRequestBehavior.AllowGet) : null;
            }
            
        }
    }
}