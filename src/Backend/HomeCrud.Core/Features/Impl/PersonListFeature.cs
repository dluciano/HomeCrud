using HomeCrud.Core.Abstract;
using HomeCrud.Core.Response;
using HomeCrud.DA.Common;
using HomeCrud.Entities;
using System.Collections.Generic;

namespace HomeCrud.Core.Impl
{
    public class PersonListFeature : IPersonListFeature
    {
        private readonly IReadRepository<Person> _people;

        public PersonListFeature(IReadRepository<Person> people)
        {
            _people = people;
        }

        IEnumerable<PersonListRowResponse> IPersonListFeature.Exec()=>
            _people.AsRow();
    }
}