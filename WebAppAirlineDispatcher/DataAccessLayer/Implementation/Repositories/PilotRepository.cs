using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PilotRepository : IRepository<Pilot>
    {
        IDataSource dataSource;

        public PilotRepository(IDataSource data)
        {
            dataSource = data;
        }

        public void Create(Pilot entity)
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

        public IEnumerable<Pilot> Find(Func<Pilot, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Pilot Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pilot> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Pilot entity)
        {
            throw new NotImplementedException();
        }
    }
}
