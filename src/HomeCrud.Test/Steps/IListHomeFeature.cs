using System.Collections.Generic;

namespace HomeCrud.Test.Specs
{
    public interface IListHomeFeature
    {
        IEnumerable<HomeRowResponse> Exec();
    }
}