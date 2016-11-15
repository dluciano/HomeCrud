using System.Linq;

namespace HomeCrud.Test.Specs
{
    public interface IDataSource<TEntity> :
        IQueryable<TEntity>
        where TEntity : class, IEntity
    {
        void Add(TEntity entity);
    }
}