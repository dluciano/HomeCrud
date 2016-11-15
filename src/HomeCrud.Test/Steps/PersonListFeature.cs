using HomeCrud.Test.Steps;
using System.Collections.Generic;

namespace HomeCrud.Test.Specs
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