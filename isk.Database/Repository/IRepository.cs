using isk.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isk.Database.Repository
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> Get<T>() where T : BaseEntity;
        T Get<T>(Guid Id) where T : BaseEntity;
        T Create<T>(T entity) where T : BaseEntity;
        T Update<T>(T entity) where T : BaseEntity;
        bool Delete<T>(T entity, bool hardDelete = false) where T : BaseEntity;
    }
}
