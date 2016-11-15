using HomeCrud.Core.Abstract;
using HomeCrud.Core.Response;
using HomeCrud.DA.Common;
using HomeCrud.Entities;

namespace HomeCrud.Core.Impl
{
    public class PersonDetailFeature : IPersonDetailFeature
    {
        private readonly IReadRepository<Person> _personRepo;

        public PersonDetailFeature(IReadRepository<Person> personRepo)
        {
            _personRepo = personRepo;
        }

        public PersonDetailsResponse Exec(int id) =>
            new PersonDetailsResponse.Factory().Create(_personRepo.ById(id));
    }
}