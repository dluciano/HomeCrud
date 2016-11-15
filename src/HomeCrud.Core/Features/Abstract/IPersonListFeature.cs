using HomeCrud.Core.Response;
using System.Collections.Generic;

namespace HomeCrud.Core.Abstract
{
    public interface IPersonListFeature
    {
        IEnumerable<PersonListRowResponse> Exec();
    }
}