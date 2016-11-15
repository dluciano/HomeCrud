using HomeCrud.Core.Response;

namespace HomeCrud.Core.Abstract
{
    public interface IPersonDetailFeature
    {
        PersonDetailsResponse Exec(int id);
    }
}