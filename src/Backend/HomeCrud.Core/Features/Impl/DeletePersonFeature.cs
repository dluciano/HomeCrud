using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using HomeCrud.DA.Common;
using HomeCrud.Entities;
using System.Linq;

namespace HomeCrud.Core.Impl
{
    public class DeletePersonFeature : IDeletePersonFeature
    {
        private readonly IUnitOfWork _db;
        private readonly IRepository<Person> _people;
        private readonly IRepository<Home> _home;

        public DeletePersonFeature(IUnitOfWork db,
            IRepository<Person> people, IRepository<Home> home)
        {
            _people = people;
            _home = home;
            _db = db;
        }

        public void Exec(DeletePersonRequest request)
        {
            var hpme = _home.Single(h => h.People.Any(p => p.Id == request.PersonId));
            hpme.People.Remove(_people.Single(p => p.Id == request.PersonId));
            _people.Delete(request.PersonId);
            _db.SaveChanges();
        }

    }
}