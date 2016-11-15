using HomeCrud.Entities;
using System.Linq;

namespace HomeCrud.DA.Common
{
    public interface IDataSource<TEntity> :
        IQueryable<TEntity>
        where TEntity : class, IEntity
    {
        void Add(TEntity entity);
        void Delete(int id);
    }
}