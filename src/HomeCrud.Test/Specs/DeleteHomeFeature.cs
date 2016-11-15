namespace HomeCrud.Test.Specs
{
    public class DeleteHomeFeature : IDeleteHomeFeature
    {
        private IUnitOfWork _db;
        private readonly IWriteRepository<Home> _homes;

        public DeleteHomeFeature(IWriteRepository<Home> homes,
            IUnitOfWork db)
        {
            _homes = homes;
            _db = db;
        }

        public void Exec(DeleteHomeRequest request)
        {
            _homes.Delete(request.Id);
            _db.SaveChanges();
        }
    }
}