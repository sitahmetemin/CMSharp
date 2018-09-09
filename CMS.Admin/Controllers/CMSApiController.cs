using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Services.Description;
using CMS.Common.Layout;
using CMS.Common.Menu;
using CMS.DataAccsess.Services;

namespace CMS.Admin.Controllers
{
    public class CMSApiController : ApiController
    {
        // GET: api/CMSApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CMSApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CMSApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CMSApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CMSApi/5
        public void Delete(int id)
        {
        }
        public IEnumerable<PageDto> GetPages()
        {
            var pagelist = Services.PageServices.GetPages();
            return pagelist;
        }
        
        public IEnumerable<MenuDto> GetMenu()
        {
            var model = Services.MenuService.GetMenus();
            var parentModel = model.Where(x => x.ParentId == null).ToList();

            List<MenuDto> menu = new List<MenuDto>();
            foreach (var parent in parentModel)
            {
                menu.Add(parent);
                var childModel = model.Where(x => x.ParentId == parent.Id).ToList();
                foreach (var child in childModel)
                {
                    menu.Add(child);
                    var subchildModel = model.Where(x => x.ParentId == child.Id).ToList();
                    foreach (var subchild in subchildModel)
                    {
                        menu.Add(subchild);
                    }
                }
            }

            return menu;
        }
        

        [HttpGet]
        public List<PageContentDto> Preview(int id)
        {
            var list = Services.PageServices.GetPageById(id);
            return list;
        }

    }
}
