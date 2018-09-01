using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DataAccsess.Concrate;

namespace CMS.DataAccsess.Services
{
    public class UnitOfWork
    {
        public  CMSContext Current { get { return new CMSContext();} }
    }
}
