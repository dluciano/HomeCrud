using HomeCrud.Test.Steps;
using System.Collections.Generic;

namespace HomeCrud.Test.Specs
{
    public class ListHomeFeature : IListHomeFeature
    {
        private readonly IReadRepository<Home> _homes;

        public ListHomeFeature(IReadRepository<Home> homes)
        {
            _homes = homes;
        }

        IEnumerable<HomeRowResponse> IListHomeFeature.Exec() =>
            _homes.AsRowCollection();
    }
}