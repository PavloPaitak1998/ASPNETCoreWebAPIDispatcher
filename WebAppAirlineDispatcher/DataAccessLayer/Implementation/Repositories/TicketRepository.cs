using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Implementation.Repositories
{
    public class TicketRepository : Repository<Ticket>
    {
        public TicketRepository(IDataSource data):base(data)
        {
        }

        public override Ticket Get(int id)
        {
            return dataSource.TicketList.Find(t => t.Id == id);
        }

        public override void Update(Ticket entity)
        {
            var ticket = dataSource.TicketList.Find(t => t.Id == entity.Id);

            if (entity.FlightNumber != 0)
                ticket.FlightNumber = entity.FlightNumber;
            if (entity.Price != 0.0)
                ticket.Price = entity.Price;

        }
    }
}
