using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class FlightRepository : Repository<Flight>
    {
        new IDataSource dataSource;

        public FlightRepository(IDataSource data):base(data)
        {
            dataSource = data;
        }

        public override Flight Get(int number)
        {
            return dataSource.FlightList.Find(f => f.Number == number);
        }

        public override void Update(Flight entity)
        {
            var flight = dataSource.FlightList.Find(f => f.Number == entity.Number);

            if (entity.DepartureTime != DateTime.MinValue)
                flight.DepartureTime = entity.DepartureTime;
            if (entity.PointOfDeparture != null)
                flight.PointOfDeparture = entity.PointOfDeparture;
            if (entity.Destination != null)
                flight.Destination = entity.Destination;
            if (entity.DestinationTime != DateTime.MinValue)
                flight.DestinationTime = entity.DestinationTime;
            if (entity.TicketsId != null && entity.TicketsId.Count()>0)
                flight.TicketsId = entity.TicketsId;
        }

    }
}
