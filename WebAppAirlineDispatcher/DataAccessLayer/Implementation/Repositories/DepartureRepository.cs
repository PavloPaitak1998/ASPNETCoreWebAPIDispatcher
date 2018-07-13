using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Implementation.Repositories
{
    public class DepartureRepository : Repository<Departure>
    {
        public DepartureRepository(IDataSource data):base(data)
        {
        }

        public override Departure Get(int id)
        {
            return dataSource.DepartureList.Find(d => d.Id == id);
        }

        public override void Update(Departure entity)
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
    }
}
