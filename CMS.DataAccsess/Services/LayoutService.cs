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
                return _repo.Query<Layout>().Select(p => new LayoutDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsDeleted = p.IsDeleted,
                    Items = p.LayoutItems.Select(x => new LItemDto()
                    {
                        Id = x.Id,
                        Class = x.Class
                    })
                }).ToList();
            }
        }

        public LayoutDto GetLayoutById(int Id)
        {
            throw new NotImplementedException();
        }

        public void InsertNewLayout(LayoutDto model)
        {
            throw new NotImplementedException();
        }

        public void UpdateLayout(LayoutDto model)
        {
            throw new NotImplementedException();
        }

        public void DeleteLayout(LayoutDto model)
        {
            throw new NotImplementedException();
        }
    }
}