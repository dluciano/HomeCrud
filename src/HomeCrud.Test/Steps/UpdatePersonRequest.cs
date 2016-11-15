namespace HomeCrud.Test.Specs
{
    public class UpdatePersonRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Identification { get; set; }

        public void FillEntity(Person person)
        {
            person.FirstName = FirstName;
            person.LastName = LastName;
            person.Gender = Gender;
            person.Identification = Identification;
        }
    }
}