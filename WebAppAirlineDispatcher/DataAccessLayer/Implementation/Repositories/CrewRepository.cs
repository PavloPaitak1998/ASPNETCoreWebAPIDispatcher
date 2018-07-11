using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        IDataSource dataSource;

        public CrewRepository(IDataSource data)
        {
            dataSource = data;
        }

        public void Create(Crew entity)
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

        public IEnumerable<Crew> Find(Func<Crew, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Crew Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Crew> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Crew entity)
        {
            throw new NotImplementedException();
        }
    }
}
