using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        protected readonly IDataSource dataSource;

        public Repository(IDataSource data)
        {
            dataSource = data;
        }

        public virtual void Create(TEntity entity)
        {
            (dataSource.GetData<TEntity>() as List<TEntity>).Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            (dataSource.GetData<TEntity>() as List<TEntity>).Remove(entity);        
        }

        public virtual void DeleteAll()
        {
            var list = (dataSource.GetData<TEntity>() as List<TEntity>);
            list.RemoveRange(0, list.Count());
        }

        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return (dataSource.GetData<TEntity>() as List<TEntity>).Where(predicate);
        }

        public virtual TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return (dataSource.GetData<TEntity>() as List<TEntity>);
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
