namespace HomeCrud.Test.Specs
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public Gender Gender { get; internal set; }
        public string Identification { get; internal set; }

        public virtual Home Home { get; set; }
    }
}