using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CMS.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _MenuPartial()
        {
            //Todo : Resimerli(Slideri Yap) ve menüleri listele
            string url = "http://localhost:57404/api/CMSApi/GetMenu/";
            WebClient client = new WebClient();
            //client.Headers.Add("user-agent")
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString(url);
            var model = JsonConvert.DeserializeObject(json);
            return PartialView("_MenuPartial", model);
        }


        [ValidateInput(false)]
        public ActionResult Preview(int id)
        {
            string url = $"http://localhost:57404/api/CMSApi/Preview/{id}";
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString(url);
            var model = JsonConvert.DeserializeObject(json);
            return View("Preview", model);
        }
    }
}