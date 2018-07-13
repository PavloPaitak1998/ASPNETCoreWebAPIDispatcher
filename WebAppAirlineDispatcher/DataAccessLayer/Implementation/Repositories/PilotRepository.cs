using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PilotRepository : Repository<Pilot>
    {
        public PilotRepository(IDataSource data):base(data)
        {
        }
        public override Pilot Get(int id)
        {
            return dataSource.PilotList.Find(p => p.Id == id);
        }

        public override void Update(Pilot entity)
        {
            var pilot = dataSource.PilotList.Find(p => p.Id == entity.Id);

            if (entity.FirstName != null)
                pilot.FirstName = entity.FirstName;
            if (entity.LastName != null)
                pilot.LastName = entity.LastName;
            if (entity.BirthDate != DateTime.MinValue)
                pilot.BirthDate = entity.BirthDate;
            if (entity.Experience != -1)
                pilot.Experience = entity.Experience;
        }
    }
}
