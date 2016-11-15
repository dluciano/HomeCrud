namespace HomeCrud.Test.Specs
{
    public class UpdateHomeRequest :
        IFromEntity<Home>

    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public Home FromEntity(Home entity)
        {
            entity.Address = Address;
            entity.Name = Name;
            return entity;
        }
    }
}