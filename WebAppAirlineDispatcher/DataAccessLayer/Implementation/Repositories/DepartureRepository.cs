using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        IDataSource dataSource;

        public DepartureRepository(IDataSource data)
        {
            dataSource = data;
        }

        public Departure Get(int id)
        {
            return dataSource.DepartureList.Find(d => d.Id == id);
        }

        public IEnumerable<Departure> GetAll()
        {
            return dataSource.DepartureList;
        }

        public void Create(Departure entity)
        {
            dataSource.DepartureList.Add(entity);
        }

        public IEnumerable<Departure> Find(Func<Departure, bool> predicate)
        {
            return dataSource.DepartureList.Where(predicate);
        }

        public void Update(Departure entity)
        {
            var departure = dataSource.DepartureList.Find(d => d.Id == entity.Id);

            if (entity.FlightNumber != 0)
                departure.FlightNumber = entity.FlightNumber;
            if (entity.CrewId != 0)
                departure.CrewId = entity.CrewId;
            if (entity.PlaneId != 0)
                departure.PlaneId = entity.PlaneId;
            if (entity.Time != DateTime.MinValue)
                departure.Time = entity.Time;
        }

        public void Delete(int id)
        {
            var departures = dataSource.DepartureList;

            departures.Remove(departures.Find(d => d.Id == id));
        }

        public void DeleteAll()
        {
            var departures = dataSource.DepartureList;

            departures.RemoveRange(0, departures.Count());
        }
    }
}
