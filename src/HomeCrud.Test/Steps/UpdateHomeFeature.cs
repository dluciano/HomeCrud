namespace HomeCrud.Test.Specs
{
    public class UpdateHomeFeature : IUpdateHomeFeature
    {
        private readonly IUnitOfWork _db;
        private readonly IRepository<Home> _repo;

        public UpdateHomeFeature(IRepository<Home> repo,
            IUnitOfWork db)
        {
            _repo = repo;
            _db = db;
        }

        public void Exec(UpdateHomeRequest request)
        {
            request.FromEntity(_repo.ById(request.Id));
            _db.SaveChanges();
        }
    }
}