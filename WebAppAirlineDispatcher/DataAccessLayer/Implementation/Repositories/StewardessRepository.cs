using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Implementation.Repositories
{
    public class StewardessRepository : Repository<Stewardess>
    {
        public StewardessRepository(IDataSource data):base(data)
        {
        }

        public override Stewardess Get(int id)
        {
            return dataSource.StewardessList.Find(s => s.Id == id);
        }

        public override void Update(Stewardess entity)
        {
            var stewardess = dataSource.StewardessList.Find(s => s.Id == entity.Id);

            if (entity.FirstName != null)
                stewardess.FirstName = entity.FirstName;
            if (entity.LastName != null)
                stewardess.LastName = entity.LastName;
            if (entity.BirthDate != DateTime.MinValue)
                stewardess.BirthDate = entity.BirthDate;
        }
    }
}
