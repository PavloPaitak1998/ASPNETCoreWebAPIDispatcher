using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        IDataSource dataSource;

        public TicketRepository(IDataSource data)
        {
            dataSource = data;
        }

        public void Create(Ticket entity)
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

        public IEnumerable<Ticket> Find(Func<Ticket, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
