namespace HomeCrud.Test.Specs
{
    using System;
    using System.Linq;
    public class DeleteHomeFeature : IDeleteHomeFeature
    {
        private readonly IUnitOfWork _db;
        private readonly IRepository<Home> _homes;
        private readonly IWriteRepository<Person> _people;

        public DeleteHomeFeature(IRepository<Home> homes,
            IWriteRepository<Person> people,
            IUnitOfWork db)
        {
            _homes = homes;
            _people = people;
            _db = db;
        }

        public void Exec(DeleteHomeRequest request)
        {
            _homes.ById(request.Id)
                .People
                .Select(p => p.Id)
                .ToList()
                .ForEach(_people.Delete);
            _homes.Delete(request.Id);
            _db.SaveChanges();
        }
    }
}