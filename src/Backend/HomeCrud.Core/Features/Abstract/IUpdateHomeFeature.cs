using HomeCrud.Core.Request;

namespace HomeCrud.Core.Abstract
{
    public interface IUpdateHomeFeature
    {
        void Exec(UpdateHomeRequest request);
    }
}