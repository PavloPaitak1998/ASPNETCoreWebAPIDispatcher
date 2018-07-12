using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class StewardessRepository : IRepository<Stewardess>
    {
        IDataSource dataSource;

        public StewardessRepository(IDataSource data)
        {
            dataSource = data;
        }

        public Stewardess Get(int id)
        {
            return dataSource.StewardessList.Find(s => s.Id == id);
        }

        public IEnumerable<Stewardess> GetAll()
        {
            return dataSource.StewardessList;
        }

        public void Create(Stewardess entity)
        {
            dataSource.StewardessList.Add(entity);
        }


        public IEnumerable<Stewardess> Find(Func<Stewardess, bool> predicate)
        {
            return dataSource.StewardessList.Where(predicate);
        }

        public void Update(Stewardess entity)
        {
            var stewardess = dataSource.StewardessList.Find(s => s.Id == entity.Id);

            if (entity.FirstName != null)
                stewardess.FirstName = entity.FirstName;
            if (entity.LastName != null)
                stewardess.LastName = entity.LastName;
            if (entity.BirthDate != DateTime.MinValue)
                stewardess.BirthDate = entity.BirthDate;
        }

        public void Delete(int id)
        {
            var stewardesses = dataSource.StewardessList;

            stewardesses.Remove(stewardesses.Find(s => s.Id == id));
        }

        public void DeleteAll()
        {
            var stewardesses = dataSource.StewardessList;

            stewardesses.RemoveRange(0, stewardesses.Count());
        }
    }
}
