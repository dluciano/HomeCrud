namespace HomeCrud.Test.Specs
{
    public class WriteRepository<TEntity>
        : IWriteRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly IDataSource<TEntity> _dataSource;

        public WriteRepository(IDataSource<TEntity> dataSource)
        {
            _dataSource = dataSource;
        }

        public void Add(TEntity entity) =>
            _dataSource.Add(entity);
    }
}