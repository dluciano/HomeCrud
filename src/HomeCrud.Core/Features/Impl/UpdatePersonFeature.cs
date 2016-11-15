using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using HomeCrud.DA.Common;
using HomeCrud.Entities;

namespace HomeCrud.Core.Impl
{
    public class UpdatePersonFeature : IUpdatePersonFeature
    {
        private readonly IUnitOfWork _db;
        private readonly IReadRepository<Person> _people;

        public UpdatePersonFeature(IReadRepository<Person> people,
            IUnitOfWork db)
        {
            _people = people;
            _db = db;
        }

        public void Exec(UpdatePersonRequest request)
        {
            request.FillEntity(_people.ById(request.Id));
            _db.SaveChanges();
        }
    }
}