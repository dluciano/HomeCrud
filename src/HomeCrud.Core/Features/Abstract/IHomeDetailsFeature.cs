using HomeCrud.Core.Request;
using HomeCrud.Core.Response;

namespace HomeCrud.Core.Abstract
{
    public interface IHomeDetailsFeature
    {
        HomeDetailsResponse Exec(HomeDetailsRequest request);
    }
}