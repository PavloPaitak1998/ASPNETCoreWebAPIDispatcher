using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        IDataSource dataSource;

        public FlightRepository(IDataSource data)
        {
            dataSource = data;
        }

        public Flight Get(int number)
        {
            return dataSource.FlightList.Find(f => f.Number == number);
        }

        public IEnumerable<Flight> GetAll()
        {
            return dataSource.FlightList;
        }

        public void Create(Flight entity)
        {
            dataSource.FlightList.Add(entity);
        }

        public IEnumerable<Flight> Find(Func<Flight, bool> predicate)
        {
            return dataSource.FlightList.Where(predicate);
        }

        public void Update(Flight entity)
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

        public void Delete(int number)
        {
            var flights = dataSource.FlightList;

            flights.Remove(flights.Find(f=>f.Number==number));
        }

        public void DeleteAll()
        {
            var flights = dataSource.FlightList;

            flights.RemoveRange(0, flights.Count());
        }
    }
}
