using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PlaneTypeRepository : IRepository<PlaneType>
    {
        IDataSource dataSource;

        public PlaneTypeRepository(IDataSource data)
        {
            dataSource = data;
        }

        public PlaneType Get(int id)
        {
            return dataSource.PlaneTypeList.Find(pt => pt.Id == id);
        }

        public IEnumerable<PlaneType> GetAll()
        {
            return dataSource.PlaneTypeList;
        }

        public void Create(PlaneType entity)
        {
            dataSource.PlaneTypeList.Add(entity);
        }

        public IEnumerable<PlaneType> Find(Func<PlaneType, bool> predicate)
        {
            return dataSource.PlaneTypeList.Where(predicate);
        }

        public void Update(PlaneType entity)
        {
            var planeType = dataSource.PlaneTypeList.Find(pt => pt.Id == entity.Id);

            if (entity.Model != null)
                planeType.Model = entity.Model;
            if (entity.Seats != 0)
                planeType.Seats = entity.Seats;
            if (entity.Carrying != 0)
                planeType.Carrying = entity.Carrying;
        }

        public void Delete(int id)
        {
            var planeTypes = dataSource.PlaneTypeList;

            planeTypes.Remove(planeTypes.Find(pt => pt.Id == id));
        }

        public void DeleteAll()
        {
            var planeTypes = dataSource.PlaneTypeList;

            planeTypes.RemoveRange(0, planeTypes.Count());
        }
    }
}
