using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Implementation.Repositories
{
    public class CrewRepository : Repository<Crew>
    {
        public CrewRepository(IDataSource data):base(data)
        {
        }

        public override Crew Get(int id)
        {
            return dataSource.CrewList.Find(c => c.Id == id);
        }

        public override void Update(Crew entity)
        {
            var flight = dataSource.CrewList.Find(c => c.Id == entity.Id);

            if (entity.PilotId != 0)
                flight.PilotId = entity.PilotId;
            if (entity.StewardessesId != null)
                flight.StewardessesId = entity.StewardessesId;
        }
    }
}
