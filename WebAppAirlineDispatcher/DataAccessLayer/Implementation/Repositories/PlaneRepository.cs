using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PlaneRepository : IRepository<Plane>
    {
        IDataSource dataSource;

        public PlaneRepository(IDataSource data)
        {
            dataSource = data;
        }

        public void Create(Plane entity)
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

        public IEnumerable<Plane> Find(Func<Plane, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Plane Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plane> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Plane entity)
        {
            throw new NotImplementedException();
        }
    }
}
