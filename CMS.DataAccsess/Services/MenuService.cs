using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Layout;
using CMS.Common.Menu;
using CMS.DataAccsess.Repository;
using CMS.DataAccsess.Services.InterFaces;
using CMS.Domain.Conrate;

namespace CMS.DataAccsess.Services
{
    public class MenuService : IMenuService
    {
        public IEnumerable<MenuDto> GetMenus()
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                return _repo.Query<Menu>().Select(m => new MenuDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Pages = m.Page.Select(x => new PageDto()
                    {
                        Name = x.Name,
                        LayoutId =x.LayoutId
                    })
                }).ToList();
            }
        }

        public MenuDto GetMenuByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void InsertNewMenu(string Name, int ParentId, string icon)
        {
            throw new NotImplementedException();
        }

        public void UpdateMenu(string Name, int ParentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMenu(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
