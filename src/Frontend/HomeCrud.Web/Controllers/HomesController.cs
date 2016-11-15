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
        private readonly IUpdateHomeFeature _updateFeature;
        private readonly IDeleteHomeFeature _deleteFeature;


        public HomesController(IListHomeFeature listHomeFeature,
            IHomeDetailsFeature detailsHomeFeature,
            ICreateHomeFeature createFeature,
            IUpdateHomeFeature updateFeature,
            IDeleteHomeFeature deleteFeature)
        {
            _listHomeFeature = listHomeFeature;
            _detailsHomeFeature = detailsHomeFeature;
            _createFeature = createFeature;
            _updateFeature = updateFeature;
            _deleteFeature = deleteFeature;
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

        public ActionResult Update(int id) => View(new UpdateHomeRequest { Id = id });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateHomeRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            _updateFeature.Exec(request);
            return RedirectToAction("Details", new { id = request.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _deleteFeature.Exec(new DeleteHomeRequest { Id = id });
            return RedirectToAction("Index");
        }
    }
}