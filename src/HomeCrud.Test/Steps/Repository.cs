namespace HomeCrud.Test.Specs
{
    public class Repository<TEntity> :
        ReadRepository<TEntity>,
        IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IWriteRepository<TEntity> _writeRepo;

        public Repository(IDataSource<TEntity> dataSource, IWriteRepository<TEntity> writeRepo)
            : base(dataSource)
        {
            _writeRepo = writeRepo;
        }

        public void Add(TEntity entity) => _writeRepo.Add(entity);

        public void Delete(int id) => _writeRepo.Delete(id);
    }
}