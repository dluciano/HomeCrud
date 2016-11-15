using System.Linq;

namespace HomeCrud.Test.Specs
{
    public interface IReadRepository<TEntity> :
        IQueryable<TEntity>
        where TEntity : class, IEntity
    {
    }
}