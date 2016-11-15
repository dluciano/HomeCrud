using HomeCrud.Core.Abstract;
using HomeCrud.Core.Response;
using HomeCrud.DA.Common;
using HomeCrud.Entities;
using System.Collections.Generic;

namespace HomeCrud.Core.Impl
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