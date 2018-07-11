using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PlaneTypeRepository : IRepository<PlaneType>
    {
        IDataSource dataSource;

        public PlaneTypeRepository(IDataSource data)
        {
            dataSource = data;
        }

        public void Create(PlaneType entity)
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

        public IEnumerable<PlaneType> Find(Func<PlaneType, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public PlaneType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaneType> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PlaneType entity)
        {
            throw new NotImplementedException();
        }
    }
}
