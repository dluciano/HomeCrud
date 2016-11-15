using HomeCrud.Core.Request;

namespace HomeCrud.Core.Abstract
{
    public interface ICreateHomeFeature
    {
        void Exec(CreateHomeRequest request);
    }
}