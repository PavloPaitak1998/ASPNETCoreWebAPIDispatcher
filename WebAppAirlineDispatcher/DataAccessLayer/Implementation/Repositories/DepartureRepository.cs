using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        IDataSource dataSource;

        public DepartureRepository(IDataSource data)
        {
            dataSource = data;
        }

        public void Create(Departure entity)
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

        public IEnumerable<Departure> Find(Func<Departure, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Departure Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departure> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Departure entity)
        {
            throw new NotImplementedException();
        }
    }
}
