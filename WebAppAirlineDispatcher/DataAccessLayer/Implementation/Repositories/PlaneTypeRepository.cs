using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Implementation.Repositories
{
    public class PlaneTypeRepository : Repository<PlaneType>
    {
        public PlaneTypeRepository(IDataSource data):base(data)
        {
        }

        public override PlaneType Get(int id)
        {
            return dataSource.PlaneTypeList.Find(pt => pt.Id == id);
        }

        public override void Update(PlaneType entity)
        {
            var planeType = dataSource.PlaneTypeList.Find(pt => pt.Id == entity.Id);

            if (entity.Model != null)
                planeType.Model = entity.Model;
            if (entity.Seats != 0)
                planeType.Seats = entity.Seats;
            if (entity.Carrying != 0)
                planeType.Carrying = entity.Carrying;
        }
    }
}
