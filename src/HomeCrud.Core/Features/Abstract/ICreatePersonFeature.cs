using HomeCrud.Core.Request;

namespace HomeCrud.Core.Abstract
{
    public interface ICreatePersonFeature
    {
        void Exec(CreatePersonRequest request);
    }
}