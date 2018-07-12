using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PlaneRepository : IRepository<Plane>
    {
        IDataSource dataSource;

        public PlaneRepository(IDataSource data)
        {
            dataSource = data;
        }

        public Plane Get(int id)
        {
            return dataSource.PlaneList.Find(p => p.Id == id);
        }

        public IEnumerable<Plane> GetAll()
        {
            return dataSource.PlaneList;
        }

        public void Create(Plane entity)
        {
            dataSource.PlaneList.Add(entity);
        }

        public IEnumerable<Plane> Find(Func<Plane, bool> predicate)
        {
            return dataSource.PlaneList.Where(predicate);
        }

        public void Update(Plane entity)
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

        public void Delete(int id)
        {
            var planes = dataSource.PlaneList;

            planes.Remove(planes.Find(p => p.Id == id));
        }

        public void DeleteAll()
        {
            var planes = dataSource.PlaneList;

            planes.RemoveRange(0, planes.Count());
        }
    }
}
