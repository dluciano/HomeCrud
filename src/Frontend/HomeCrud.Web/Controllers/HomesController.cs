using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using System.Linq;
using System.Web.Mvc;

namespace HomeCrud.Web.Controllers
{
    public class HomesController : Controller
    {
        private readonly IListHomeFeature _listHomeFeature;
        private readonly ICreateHomeFeature _createFeature;
        private readonly IHomeDetailsFeature _detailsHomeFeature;

        public HomesController(IListHomeFeature listHomeFeature,
            IHomeDetailsFeature detailsHomeFeature,
            ICreateHomeFeature createFeature)
        {
            _listHomeFeature = listHomeFeature;
            _detailsHomeFeature = detailsHomeFeature;
            _createFeature = createFeature;
        }

        public ActionResult Index() => View(_listHomeFeature.Exec().ToList());

        public ActionResult Details(int id) =>
               View(_detailsHomeFeature.Exec(new HomeDetailsRequest { Id = id }));


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