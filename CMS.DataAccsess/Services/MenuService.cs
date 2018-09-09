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
                return _repo.Query<Menu>().Where(m => !m.IsDeleted).Select(m => new MenuDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    UpdatedAt = m.UpdatedAt,
                    ParentId = m.ParentId,
                    Pages = m.Page.Select(x => new PageDto()
                    {
                        Name = x.Name,
                        LayoutId = x.LayoutId
                    })
                }).ToList();
            }
        }

        public string GetMenuRecursion()
        {
            using (BaseRepository<Menu> repo = new BaseRepository<Menu>())
            {
                var all = repo.Query<Menu>().Where(x => !x.IsDeleted).ToList();
                var pageTum = repo.Query<Page>().Where(k => !k.IsDeleted).ToList();
                var strBuilder = new StringBuilder();
                var parentItems = all.Where(x => x.ParentId == null).ToList();

                foreach (var parentcat in parentItems)
                {
                    var childItems = all.Where(x => x.ParentId == parentcat.Id);
                    if (childItems.Count() > 0)
                    {
                        var page = repo.Query<Page>().Where(k => k.MenuId == parentcat.Id).FirstOrDefault();
                        strBuilder.Append("<li class='dropdown' ><a href='Home/Preview/" + parentcat.Id + "'>" +
                                          page.Name + "</a>");
                        AddChildItem(parentcat, strBuilder, all, pageTum);
                        strBuilder.Append("</li>");
                    }
                    else
                    {
                        var page = repo.Query<Page>().Where(k => k.MenuId == parentcat.Id).FirstOrDefault();
                        strBuilder.Append("<li><a href='Home/Preview/" + parentcat.Id + "'>" + page.Name + "</a>" +
                                          "</li>");
                    }
                }

                return strBuilder.ToString();
            }
        }

        public void AddChildItem(Menu childItem, StringBuilder strBuilder, List<Menu> MenuTum, List<Page> pageTum)
        {
            using (BaseRepository<Menu> repo = new BaseRepository<Menu>())
            {
                strBuilder.Append("<ul>");
                var childItems = MenuTum.Where(x => x.Id == childItem.Id);
                foreach (Menu cItem in childItems)
                {
                    var subChilds = MenuTum.Where(x => x.Id == cItem.Id);
                    if (subChilds.Count() > 0)
                    {
                        var page = pageTum.Where(k => k.MenuId == cItem.Id).FirstOrDefault();
                        strBuilder.Append("<li class='dropdown-menu'><a href='Home/Preview/" + cItem.Id + "'>" +
                                          page.Name + "</a>");
                        AddChildItem(cItem, strBuilder, MenuTum, pageTum);
                        strBuilder.Append("</li>");
                    }
                    else
                    {
                        var page = repo.Query<Page>().Where(k => k.MenuId == cItem.Id).FirstOrDefault();
                        strBuilder.Append("<li><a href='Home/Preview/" + cItem.Id + "'>" + page.Name + "</a></li>");
                    }
                }

                strBuilder.Append("</ul>");
            }
        }

        public MenuDto GetMenuByName(string Name)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                return _repo.Query<Menu>().Where(p => p.Name == Name).Select(p => new MenuDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ParentId = p.ParentId,
                    Icon = p.Icon
                }).FirstOrDefault();
            }
        }

        public void InsertNewMenu(string Name, int? ParentId, string icon)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                Menu simleMenu = new Menu
                {
                    Name = Name,
                    Icon = icon,
                    ParentId = ParentId
                };
                _repo.Add(simleMenu);
            }
        }

        public void UpdateMenu(string Name, int? ParentId, string icon, string oldName)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                //Layout Güncelleme İşlemi
                var menuBilgiler = _repo.Query<Menu>().FirstOrDefault(c => c.Name == oldName);
                menuBilgiler.Name = Name;
                menuBilgiler.ParentId = ParentId;
                menuBilgiler.Icon = icon;
                _repo.Update(menuBilgiler);
            }
        }

        public void DeleteMenu(string Name)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                var layout = _repo.Query<Menu>().Where(c => c.Name == Name).FirstOrDefault();
                _repo.DeleteAt(layout);
            }
        }
    }
}