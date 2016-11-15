using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using System.Web.Mvc;

namespace HomeCrud.Web.Controllers
{
    public class HomesController : Controller
    {
        private readonly ICreateHomeFeature _createFeature;

        public HomesController(ICreateHomeFeature createFeature)
        {
            _createFeature = createFeature;
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateHomeRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            _createFeature.Exec(request);
            return RedirectToAction("Index");
        }
    }
}