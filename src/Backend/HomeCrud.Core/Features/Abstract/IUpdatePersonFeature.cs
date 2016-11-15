using HomeCrud.Core.Request;

namespace HomeCrud.Core.Abstract
{
    public interface IUpdatePersonFeature
    {
        void Exec(UpdatePersonRequest request);
    }
}