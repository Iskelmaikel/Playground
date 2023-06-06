using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using isk.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace isk.Database.Repository
{
    public class Repository<TContext> : IRepository where TContext : DbContext
    {
        private TContext DbContext;

        public Repository(TContext context)
        {
            this.DbContext = context;
        }

        public bool Delete<TEntity>(TEntity entity, bool hardDelete = false) where TEntity : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var dbEntity = DbContext.Set<TEntity>()
                .Where(s => s.Id == entity.Id)
                .Where(s => s.DeletedOn == null)
                .FirstOrDefault();
            if (dbEntity == null || dbEntity.Id.Equals(Guid.Empty))
            {
                throw new NullReferenceException("Entity to update could not be found");
            }
            if (hardDelete)
            {
                DbContext.Remove<TEntity>(entity);
            }
            else
            {
                // Soft delete the entity
                entity.DeletedBy = "System deleted";
                entity.DeletedOn = DateTime.UtcNow;
                DbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            }
            DbContext.SaveChanges();
            return true;
        }

        public TEntity Get<TEntity>(Guid Id) where TEntity : BaseEntity
        {
            return DbContext.Set<TEntity>()
                .Where(s => s.Id == Id)
                .Where(s => s.DeletedOn == null)
                .FirstOrDefault();
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : BaseEntity
        {
            return DbContext.Set<TEntity>()
                .Where(s => s.DeletedOn == null);
        }

        public TEntity Create<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.Id == null || entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            if (string.IsNullOrEmpty(entity.CreatedBy))
            {
                entity.CreatedBy = "System created";
            }
            if (entity.CreatedOn == null)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
            BaseEntity localEntity = DbContext.Set<TEntity>()
                .Where(s => s.Id == entity.Id)
                .Where(s => s.DeletedOn == null)
                .FirstOrDefault();
            if (localEntity != null)
            {
                throw new InvalidOperationException("Entity already exists.");
            }
            DbContext.Add<TEntity>(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            // Check if the entity can be found in the db.
            var dbEntity = DbContext.Set<TEntity>()
                .Where(s => s.Id == entity.Id)
                .Where(s => s.DeletedOn == null)
                .FirstOrDefault();
            if (dbEntity == null || dbEntity.Id.Equals(Guid.Empty))
            {
                throw new NullReferenceException("Entity to update could not be found");
            }
            if (entity.CreatedBy == null)
            {
                entity.CreatedBy = "System created";
            }

            if (entity.CreatedOn == null)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }

            entity.ModifiedBy = "System modified";
            entity.ModifiedOn = DateTime.UtcNow;

            // Update the found object with the new values
            DbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            DbContext.SaveChanges();

            return entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
