using HomeCrud.Entities;

namespace HomeCrud.Core.Response
{
    public class PersonDetailsResponse
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }
        public string Identification { get; private set; }
        public string Home { get; private set; }
        public int HomeId { get; private set; }

        private PersonDetailsResponse() { }

        public class Factory : IFactory<Person, PersonDetailsResponse>
        {
            public PersonDetailsResponse Create(Person person) =>
              new PersonDetailsResponse
              {
                  Id = person.Id,
                  FirstName = person.FirstName,
                  LastName = person.LastName,
                  Gender = person.Gender,
                  Home = person.Home.Name,
                  HomeId = person.Home.Id,
                  Identification = person.Identification,
              };
        }
    }
}