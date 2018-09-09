using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CMS.Common.Layout;
using CMS.DataAccsess.Repository;
using CMS.DataAccsess.Services.InterFaces;
using CMS.Domain.Conrate;

namespace CMS.DataAccsess.Services
{
    public class PageService : BaseService, IPageServices
    {
        public IEnumerable<PageDto> GetPages()
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                return _repo.Query<Page>().Where(x => x.IsDeleted == false).Select(p => new PageDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    LayoutName = p.Layout.Name,
                }).ToList();
            }
        }

        public PageDto GetPageByName(string Name)
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                return _repo.Query<Page>().Where(x => x.Name == Name).Select(p => new PageDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    LayoutName = p.Layout.Name,
                    PageContents = p.PageContents.Select(x => new PageContentDto
                    {
                        Id = x.Id,
                        Class = x.Class,
                        PageId = x.PageId,
                        Content = x.Content
                    })
                }).FirstOrDefault();
            }
        }

        public List<PageContentDto> GetPageById(int id)
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                var bilgiler = _repo.Query<Page>().Where(c => c.Id == id).FirstOrDefault();

                using (BaseRepository<PageContent> repository = new BaseRepository<PageContent>())
                {
                    List<PageContentDto> icerik = new List<PageContentDto>();
                    var veriler = repository.Query<PageContent>().Where(x => x.PageId == bilgiler.Id).ToList();

                    foreach (var pageContent in veriler)
                    {
                        PageContentDto dto = new PageContentDto
                        {
                            Id = pageContent.Id,
                            Class = pageContent.Class,
                            Content = pageContent.Content,
                            PageId = pageContent.Id
                        };

                        icerik.Add(dto);
                    }

                    return icerik;
                }
                

                //return _repo.Query<Page>().Where(x => x.Id == id).Select(p => new PageDto
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    LayoutName = p.Layout.Name,
                //    PageContents = p.PageContents.Select(x => new PageContentDto
                //    {
                //        Id = x.Id,
                //        Class = x.Class,
                //        PageId = x.PageId,
                //        Content = x.Content
                //    })
                //}).FirstOrDefault();
            }
        }

        public void InsertNewPage(string Name, Array Contents, int LayoutID, int MenuId, string[] Classes)
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                Page pl = new Page
                {
                    Name = Name,
                    CreatedAt = DateTime.Now,
                    LayoutId = LayoutID,
                    IsDeleted = false,
                    Slug = GenerateSlug(Name),
                    MenuId = MenuId
                };
                _repo.Add(pl);
            }

            using (BaseRepository<PageContent> _repo = new BaseRepository<PageContent>())
            {
                var sonEklenen = _repo.Query<Page>().Where(x => x.Name == Name).FirstOrDefault();

                var i = 0;
                foreach (var icerik in Contents)
                {
                    var con = new PageContent
                    {
                        Content = icerik.ToString(),
                        CreatedAt = DateTime.Now,
                        IsDeleted = false,
                        Class = Classes[i],
                        PageId = sonEklenen.Id
                    };

                    _repo.Add(con);
                    i++;
                }
            }
        }

        public void UpdatePage(string oldName, string Name, Array Columns, int LayoutID)
        {
            throw new NotImplementedException();
        }

        public void UpdatePage(string oldName, string Name, Array Columns)
        {
            throw new NotImplementedException();
        }

        public void DeletePage(string Name)
        {
            throw new NotImplementedException();
        }

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