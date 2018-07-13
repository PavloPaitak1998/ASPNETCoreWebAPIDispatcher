using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PlaneRepository : Repository<Plane>
    {
        public PlaneRepository(IDataSource data):base(data)
        {
        }

        public override Plane Get(int id)
        {
            return dataSource.PlaneList.Find(p => p.Id == id);
        }

        public override void Update(Plane entity)
        {
            var plane = dataSource.PlaneList.Find(p => p.Id == entity.Id);

            if (entity.Name != null)
                plane.Name = entity.Name;
            if (entity.TypeId != 0)
                plane.TypeId = entity.TypeId;
            if (entity.ReleaseDate != DateTime.MinValue)
                plane.ReleaseDate = entity.ReleaseDate;
            if (entity.Lifetime != TimeSpan.MinValue)
                plane.Lifetime = entity.Lifetime;
        }
    }
}
