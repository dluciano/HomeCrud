using HomeCrud.Entities;

namespace HomeCrud.Core.Response
{
    public class PersonListRowResponse
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public Gender Gender { get; private set; }
        public string Home { get; set; }
        public string Identification { get; set; }

        public class Factory : IFactory<Person, PersonListRowResponse>
        {
            public PersonListRowResponse Create(Person entity) =>
                new PersonListRowResponse
                {
                    Id = entity.Id,
                    FullName = entity.FirstName + " " + entity.LastName,
                    Gender = entity.Gender,
                    Home = entity.Home.Name,
                    Identification = entity.Identification
                };
        }
    }
}