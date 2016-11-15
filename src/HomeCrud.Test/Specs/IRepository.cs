namespace HomeCrud.Test.Specs
{
    public interface IRepository<TEntity>
        : IWriteRepository<TEntity>,
        IReadRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}