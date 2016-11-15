namespace HomeCrud.Test.Specs
{
    public interface IWriteRepository<TEntity>
        where TEntity : IEntity
    {
        void Add(TEntity entity);
    }
}