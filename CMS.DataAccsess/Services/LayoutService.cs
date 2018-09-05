using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Layout;
using CMS.DataAccsess.Repository;
using CMS.DataAccsess.Services.InterFaces;
using CMS.Domain.Conrate;

namespace CMS.DataAccsess.Services
{
    public class LayoutService : BaseService, ILayoutService
    {
        public IEnumerable<LayoutDto> GetLayouts()
        {
            using (BaseRepository<Layout> _repo = new BaseRepository<Layout>())
            {
                return _repo.Query<Layout>().Where(x => x.IsDeleted == false).Select(p => new LayoutDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsDeleted = p.IsDeleted,
                    Items = p.LayoutItems.Select(x => new LItemDto()
                    {
                        Id = x.Id,
                        Class = x.Class,
                    })
                }).ToList();
            }
        }


        public LayoutDto GetLayoutByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void UpdateLayout(string oldName, string Name, Array columns)
        {
            Layout layout = new Layout();
            using (BaseRepository<Layout> _repo = new BaseRepository<Layout>())
            {
                //Layout Güncelleme İşlemi
                var layoutBilgiler = _repo.Query<Layout>().FirstOrDefault(c => c.Name == oldName);
                if (layoutBilgiler.Name != oldName)
                {
                    layoutBilgiler.Name = Name;
                    _repo.Update(layoutBilgiler);
                }
                
                using (BaseRepository<LayoutItem> _repository = new BaseRepository<LayoutItem>())
                {
                    //Layout İtemlerini silme işlemi
                    var eskilayoutKolonlar = _repository.Query<LayoutItem>().Where(x => x.LayoutId == layoutBilgiler.Id)
                        .ToList();
                    foreach (var oldColumn in eskilayoutKolonlar)
                    {
                        _repository.Delete(oldColumn);
                    }

                    foreach (var kolonBilgisi in columns)
                    {
                        var post = new LayoutItem { Class = kolonBilgisi.ToString(), LayoutId = layoutBilgiler.Id, UpdatedAt = DateTime.Now, CreatedAt = DateTime.Now, IsDeleted = false};
                        _repository.Add(post);
                    }

                }

            }
        }

        public void DeleteLayout(string Name)
        {
            using (BaseRepository<Layout> _repo = new BaseRepository<Layout>())
            {
                var layout = _repo.Query<Layout>().Where(c => c.Name == Name).FirstOrDefault();
                _repo.DeleteAt(layout);
            }
        }

        public void InsertNewLayout(string Name, Array Kolonlar)
        {
            Layout layout = new Layout();
            using (BaseRepository<Layout> _repo = new BaseRepository<Layout>())
            {
                Layout pl = new Layout
                {
                    Name = Name,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };
                _repo.Add(pl);
            }

            using (BaseRepository<LayoutItem> _repo = new BaseRepository<LayoutItem>())
            {
                layout = _repo.Query<Layout>().Where(c => c.Name == Name).First();


                foreach (var kolonBilgisi in Kolonlar)
                {
                    var post = new LayoutItem {Class = kolonBilgisi.ToString(), LayoutId = layout.Id,};
                    _repo.Add(post);
                }
            }
        }
    }
}