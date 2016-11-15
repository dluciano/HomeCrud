namespace HomeCrud.Test.Specs
{
    public static class RepositoryExtensions
    {
        public static void Add<TEntity>(this TEntity entity, IWriteRepository<TEntity> repo)
            where TEntity : IEntity
            =>
            repo.Add(entity);
    }
}
