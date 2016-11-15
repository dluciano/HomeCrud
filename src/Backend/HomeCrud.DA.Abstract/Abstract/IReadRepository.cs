using HomeCrud.Entities;
using System.Linq;

namespace HomeCrud.DA.Common
{
    public interface IReadRepository<TEntity> :
        IQueryable<TEntity>
        where TEntity : class, IEntity
    {
    }
}