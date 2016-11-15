using HomeCrud.Entities;

namespace HomeCrud.Core.Request
{
    public class CreatePersonRequest : IToEntity<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Identification { get; set; }
        public int Home { get; set; }

        public Person ToEntity() => new Person
        {
            FirstName = FirstName,
            LastName = LastName,
            Gender = Gender,
            Identification = Identification,
        };
    }
}