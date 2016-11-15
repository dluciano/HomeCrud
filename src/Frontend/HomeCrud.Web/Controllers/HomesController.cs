using System.Web.Mvc;

namespace HomeCrud.Web.Controllers
{
    public class HomesController : Controller
    {
        public ActionResult Create() => View();
    }
}