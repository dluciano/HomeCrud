using System;

namespace HomeCrud.Test.Specs
{
    public class HomeDetailsFeature : IHomeDetailsFeature
    {
        private readonly IReadRepository<Home> _homes;

        public HomeDetailsFeature(IReadRepository<Home> homes)
        {
            _homes = homes;
        }

        public HomeDetailsResponse Exec(HomeDetailsRequest request) =>
            new HomeDetailsResponse.Factory().Create(_homes.ById(request.Id));
    }
}