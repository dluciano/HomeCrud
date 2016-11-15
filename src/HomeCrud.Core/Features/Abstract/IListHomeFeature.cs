using HomeCrud.Core.Response;
using System.Collections.Generic;

namespace HomeCrud.Core.Abstract
{
    public interface IListHomeFeature
    {
        IEnumerable<HomeRowResponse> Exec();
    }
}