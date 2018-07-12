using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        IDataSource dataSource;

        public CrewRepository(IDataSource data)
        {
            dataSource = data;
        }

        public Crew Get(int id)
        {
            return dataSource.CrewList.Find(c => c.Id == id);
        }

        public IEnumerable<Crew> GetAll()
        {
            return dataSource.CrewList;
        }

        public void Create(Crew entity)
        {
            dataSource.CrewList.Add(entity);
        }

        public IEnumerable<Crew> Find(Func<Crew, bool> predicate)
        {
            return dataSource.CrewList.Where(predicate);
        }

        public void Update(Crew entity)
        {
            var flight = dataSource.CrewList.Find(c => c.Id == entity.Id);

            if (entity.PilotId != 0)
                flight.PilotId = entity.PilotId;
            if (entity.StewardessesId != null)
                flight.StewardessesId = entity.StewardessesId;
        }

        public void Delete(int id)
        {
            var crews = dataSource.CrewList;

            crews.Remove(crews.Find(c => c.Id == id));
        }

        public void DeleteAll()
        {
            var crews = dataSource.CrewList;

            crews.RemoveRange(0, crews.Count());
        }
    }
}
