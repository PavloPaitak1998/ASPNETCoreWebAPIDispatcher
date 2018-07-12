using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        IDataSource dataSource;

        public TicketRepository(IDataSource data)
        {
            dataSource = data;
        }
        public Ticket Get(int id)
        {
            return dataSource.TicketList.Find(t => t.Id == id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return dataSource.TicketList;
        }

        public void Create(Ticket entity)
        {
            dataSource.TicketList.Add(entity);
        }

        public IEnumerable<Ticket> Find(Func<Ticket, bool> predicate)
        {
            return dataSource.TicketList.Where(predicate);
        }

        public void Update(Ticket entity)
        {
            var ticket = dataSource.TicketList.Find(t => t.Id == entity.Id);

            if (entity.FlightNumber != 0)
                ticket.FlightNumber = entity.FlightNumber;
            if (entity.Price != 0.0)
                ticket.Price = entity.Price;

        }

        public void Delete(int id)
        {
            var tickets = dataSource.TicketList;

            tickets.Remove(tickets.Find(t => t.Id == id));
        }

        public void DeleteAll()
        {
            var tickets = dataSource.TicketList;

            tickets.RemoveRange(0, tickets.Count());
        }
    }
}
