using HomeCrud.Entities;

namespace HomeCrud.Core.Response
{
    public class HomeRowResponse
    {
        public int Id { get; private set; }
        public int People { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        private HomeRowResponse()
        {
        }

        public class Factory : IFactory<Home, HomeRowResponse>
        {
            public HomeRowResponse Create(Home entity) =>
                new HomeRowResponse
                {
                    Id = entity.Id,
                    People = entity.People.Count,
                    Name = entity.Name,
                    Address = entity.Address
                };
        }
    }
}