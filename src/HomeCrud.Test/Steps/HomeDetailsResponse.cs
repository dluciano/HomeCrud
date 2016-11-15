using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeCrud.Test.Specs
{
    public class HomeDetailsResponse
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public IEnumerable<PersonDetailRow> People { get; private set; } = new List<PersonDetailRow>();

        private HomeDetailsResponse()
        {
        }

        public class Factory : IFactory<Home, HomeDetailsResponse>
        {
            public HomeDetailsResponse Create(Home entity)
            {
                var response = new HomeDetailsResponse
                {
                    Name = entity.Name,
                    Address = entity.Address,
                };
                response.People = entity.People.Select(p => new PersonDetailRow.Factory().Create(p));
                return response;
            }
        }

        public class PersonDetailRow
        {
            public int Id { get; private set; }
            public string FullName { get; private set; }
            public Gender Gender { get; private set; }

            private PersonDetailRow()
            {
            }

            public class Factory : IFactory<Person, PersonDetailRow>
            {
                public PersonDetailRow Create(Person entity) =>
                    new PersonDetailRow
                    {
                        Id = entity.Id,
                        FullName = entity.FirstName + " " + entity.LastName,
                        Gender = entity.Gender
                    };
            }
        }
    }
}