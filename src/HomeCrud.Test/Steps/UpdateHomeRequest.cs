namespace HomeCrud.Test.Specs
{
    public class UpdateHomeRequest
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public Home IFillEntity(Home entity)
        {
            entity.Address = Address;
            entity.Name = Name;
            return entity;
        }
    }
}