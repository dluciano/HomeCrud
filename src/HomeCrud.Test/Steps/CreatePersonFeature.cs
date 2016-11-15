namespace HomeCrud.Test.Specs
{
    public class CreatePersonFeature : ICreatePersonFeature
    {
        private IUnitOfWork _db;
        private IReadRepository<Home> _homes;
        private IWriteRepository<Person> _persons;

        public CreatePersonFeature(IUnitOfWork db, IReadRepository<Home> homes, IWriteRepository<Person> persons)
        {
            _db = db;
            _homes = homes;
            _persons = persons;
        }

        public void Exec(CreatePersonRequest request)
        {
            var e = request.ToEntity();
            e.Home = _homes.ById(request.Home);
            _persons.Add(e);
            _db.SaveChanges();
        }
    }
}