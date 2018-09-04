using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.DataAccsess.Concrate;

namespace CMS.Admin.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Index()
        {
            using (CMSContext _context = new CMSContext())
            {
                var ayarlar = _context.Settings.FirstOrDefault(x => x.Id == 1);
                TempData.Add("Url", ayarlar.Url);
                TempData.Add("SiteTitle", ayarlar.SiteTitle);
                TempData.Add("Slogan", ayarlar.Slogan);
                TempData.Add("Description", ayarlar.Description);
                TempData.Add("Copyright", ayarlar.Copyright);
                TempData.Add("Ico", ayarlar.Ico);
                TempData.Add("Logo", ayarlar.Logo);
                TempData.Add("SMTPHost", ayarlar.SMTPHost);
                TempData.Add("SMTPPort", ayarlar.SMTPPort);
                TempData.Add("SMTPUser", ayarlar.SMTPUser);
                TempData.Add("SMTPPassword", ayarlar.SMTPPassword);
                TempData.Add("Facebook", ayarlar.Facebook);
                TempData.Add("Twitter", ayarlar.Twitter);
                TempData.Add("Instagram", ayarlar.Instagram);
                TempData.Add("Youtube", ayarlar.Youtube);
                TempData.Add("Linkedin", ayarlar.Linkedin);
                TempData.Add("Google", ayarlar.Google);
                TempData.Add("Github", ayarlar.Github);
                TempData.Add("Pinterest", ayarlar.Pinterest);
                TempData.Add("Tumblr", ayarlar.Tumblr);
                TempData.Add("Flickr", ayarlar.Flickr);
                TempData.Add("Reddit", ayarlar.Reddit);
                TempData.Add("Snapchat", ayarlar.Snapchat);
                TempData.Add("Whatsapp", ayarlar.Whatsapp);
            }
            return View();
        }

        [HttpPost]
        public JsonResult Save(string Url, string SiteTitle, string Slogan, string Description, string Copyright, string Logo, string Ico, string SMTPHost, string SMTPPort, string SMTPUser, string SMTPPassword, string Facebook, string Twitter, string Instagram, string Youtube, string Linkedin, string Google, string Github, string Pinterest, string Tumblr, string Flickr, string Reddit, string Snapchat, string Whatsapp)
        {
            using (CMSContext _context = new CMSContext())
            {

                var ayar = _context.Settings.FirstOrDefault(x => x.Id == 1);
                ayar.Url = Url;
                ayar.SiteTitle = SiteTitle;
                ayar.Slogan = Slogan;
                ayar.Description = Description;
                ayar.Copyright = Copyright;
                ayar.Logo = Logo;
                ayar.Ico = Ico;
                ayar.SMTPHost = SMTPHost;
                ayar.SMTPPort = SMTPPort;
                ayar.SMTPUser = SMTPUser;
                ayar.SMTPPassword = SMTPPassword;
                ayar.Facebook = Facebook;
                ayar.Twitter = Twitter;
                ayar.Instagram = Instagram;
                ayar.Youtube = Youtube;
                ayar.Linkedin = Linkedin;
                ayar.Google = Google;
                ayar.Github = Github;
                ayar.Pinterest = Pinterest;
                ayar.Tumblr = Tumblr;
                ayar.Flickr = Flickr;
                ayar.Reddit = Reddit;
                ayar.Snapchat = Snapchat;
                ayar.Whatsapp = Whatsapp;


                _context.Settings.AddOrUpdate(ayar);
                return _context.SaveChanges() > 0 ? Json("success", JsonRequestBehavior.AllowGet) : null;
            }

            //Url
            //SiteTitle
            //Slogan
            //Description
            //Copyright
            //Logo
            //SMTPHost
            //SMTPPort
            //SMTPUser
            //SMTPPassword
            //Facebook
            //Twitter
            //Instagram
            //Youtube
            //Linkedin
            //Google
            //Github
            //Pinterest
            //Tumblr
            //Flickr
            //Reddit
            //Snapchat
            //Whatsapp
        }
    }
}