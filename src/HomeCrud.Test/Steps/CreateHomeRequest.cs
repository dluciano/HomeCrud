namespace HomeCrud.Test.Specs
{
    public class CreateHomeRequest : IToEntity<Home>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public Home ToEntity() =>
            new Home()
            {
                Name = Name,
                Address = Address
            };
    }
}