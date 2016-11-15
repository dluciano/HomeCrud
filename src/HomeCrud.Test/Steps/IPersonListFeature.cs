using System.Collections.Generic;

namespace HomeCrud.Test.Specs
{
    public interface IPersonListFeature
    {
        IEnumerable<PersonListRowResponse> Exec();
    }
}