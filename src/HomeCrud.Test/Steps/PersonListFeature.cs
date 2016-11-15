using System.Collections.Generic;
using System.Linq;

namespace HomeCrud.Test.Specs
{
    public class PersonListFeature : IPersonListFeature
    {
        private readonly IReadRepository<Person> _persons;

        public PersonListFeature(IReadRepository<Person> persons)
        {
            _persons = persons;
        }

        public IEnumerable<Person> Exec() => _persons.AsEnumerable();
    }
}