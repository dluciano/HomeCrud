using HomeCrud.Entities;

namespace HomeCrud.DA.Common
{
    public interface IRepository<TEntity>
        : IWriteRepository<TEntity>,
        IReadRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}