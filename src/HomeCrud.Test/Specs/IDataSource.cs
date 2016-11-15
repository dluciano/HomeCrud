namespace HomeCrud.Test.Specs
{
    public interface IDataSource<TEntity>
        where TEntity : IEntity
    {
        void Add(TEntity entity);
    }
}