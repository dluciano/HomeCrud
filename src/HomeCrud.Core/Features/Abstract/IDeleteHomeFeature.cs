using HomeCrud.Core.Request;

namespace HomeCrud.Core.Abstract
{
    public interface IDeleteHomeFeature
    {
        void Exec(DeleteHomeRequest request);
    }
}