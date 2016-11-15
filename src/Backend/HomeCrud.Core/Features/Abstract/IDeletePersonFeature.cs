using HomeCrud.Core.Request;

namespace HomeCrud.Core.Abstract
{
    public interface IDeletePersonFeature
    {
        void Exec(DeletePersonRequest request);
    }
}