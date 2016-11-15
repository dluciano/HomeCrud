using System.Data.Entity;

namespace HomeCrud.Test.Specs
{
    public class EntityFrameworkDataSource<TEntity> :
        IDataSource<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbSet<TEntity> efDataSet;

        public EntityFrameworkDataSource(DbContext context)
        {
            efDataSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity) => efDataSet.Add(entity);
    }
}