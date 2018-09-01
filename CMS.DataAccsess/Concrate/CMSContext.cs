using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Conrate;

namespace CMS.DataAccsess.Concrate
{
    public class CMSContext : DbContext
    {
        public CMSContext() :base ("CMSContext")
        {
        }

        public virtual DbSet<Layout> Layouts { get; set; }
        public DbSet<LayoutItem> LayoutItems { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Users> Userses { get; set; }
    }
}