using HomeCrud.Entities;

namespace HomeCrud.DA.Common
{
    public interface IWriteRepository<TEntity>
        where TEntity : IEntity
    {
        void Add(TEntity entity);
        void Delete(int id);
    }
}