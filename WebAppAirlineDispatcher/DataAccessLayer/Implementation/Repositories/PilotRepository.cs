using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PilotRepository : IRepository<Pilot>
    {
        IDataSource dataSource;

        public PilotRepository(IDataSource data)
        {
            dataSource = data;
        }
        public Pilot Get(int id)
        {
            return dataSource.PilotList.Find(p => p.Id == id);
        }

        public IEnumerable<Pilot> GetAll()
        {
            return dataSource.PilotList;
        }

        public void Create(Pilot entity)
        {
            dataSource.PilotList.Add(entity);
        }

        public IEnumerable<Pilot> Find(Func<Pilot, bool> predicate)
        {
            return dataSource.PilotList.Where(predicate);
        }

        public void Update(Pilot entity)
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

        public void Delete(int id)
        {
            var pilots = dataSource.PilotList;

            pilots.Remove(pilots.Find(p => p.Id == id));
        }

        public void DeleteAll()
        {
            var pilots = dataSource.PilotList;

            pilots.RemoveRange(0, pilots.Count());
        }

    }
}
