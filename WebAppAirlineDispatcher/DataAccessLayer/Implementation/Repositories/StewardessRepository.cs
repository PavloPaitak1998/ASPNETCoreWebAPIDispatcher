using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class StewardessRepository : IRepository<Stewardess>
    {
        IDataSource dataSource;

        public StewardessRepository(IDataSource data)
        {
            dataSource = data;
        }

        public void Create(Stewardess entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stewardess> Find(Func<Stewardess, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Stewardess Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stewardess> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Stewardess entity)
        {
            throw new NotImplementedException();
        }
    }
}
