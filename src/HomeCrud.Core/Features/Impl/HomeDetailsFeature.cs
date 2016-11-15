using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using HomeCrud.Core.Response;
using HomeCrud.DA.Common;
using HomeCrud.Entities;

namespace HomeCrud.Core.Impl
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