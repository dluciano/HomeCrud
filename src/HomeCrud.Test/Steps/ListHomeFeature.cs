using System.Collections.Generic;
using System.Linq;

namespace HomeCrud.Test.Specs
{
    public class ListHomeFeature : IListHomeFeature
    {
        private readonly IReadRepository<Home> _homes;

        public ListHomeFeature(IReadRepository<Home> homes)
        {
            _homes = homes;
        }

        public IEnumerable<Home> Exec() =>
            _homes.AsEnumerable();
    }
}