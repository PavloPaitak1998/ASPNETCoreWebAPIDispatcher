using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEntityService<TEntity>where TEntity:class
    {
        TEntity GetEntity(int id);
        IEnumerable<TEntity> GetEntities();
        void CreateEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(int id);
        void DeleteAllEntities();

    }
}
