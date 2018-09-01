﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DataAccsess.Concrate;
using CMS.Domain.Abstract;

namespace CMS.DataAccsess.Repository
{
    class AbstractBaseRepository<T> : IDisposable where T : class, IBaseEntity
    {
        internal CMSContext context = null;

        public DbSet<T> Entity
        {
            get { return context.Set<T>(); }
        }

        public AbstractBaseRepository()
        {
            context = new CMSContext();
        }

        public virtual bool Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            Entity.Add(entity);

            return context.SaveChanges() > 0;
        }

        public virtual T Find(int Id)
        {
            return Entity.FirstOrDefault(x => x.Id == Id);
        }

        public virtual bool Delete(T entity)
        {
            if (entity != null && entity.Id != default(int))
            {
                var record = Find(entity.Id);
                if (record == null)
                {
                    throw new NullReferenceException(nameof(entity.Id));
                }

                record.IsDeleted = true;
                return context.SaveChanges() > 0;
            }

            throw new ArgumentOutOfRangeException(nameof(entity.Id));
        }

        public virtual bool Update(T entity)
        {
            if (entity != null && entity.Id != default(int))
            {
                throw new ArgumentOutOfRangeException(nameof(entity.Id));
            }

            var record = Find(entity.Id);
            if (record == null)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            record = entity;

            return context.SaveChanges() > 0;
        }

        public virtual IQueryable<IBaseEntity> ListAll()
        {
            return Entity;
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}