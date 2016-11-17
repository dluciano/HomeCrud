using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using System.Linq;
using System.Web.Mvc;

namespace HomeCrud.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IListHomeFeature _listHomeFeature;
        private readonly ICreatePersonFeature _createFeature;
        private readonly IPersonDetailFeature _detailsFeature;
        private readonly IUpdatePersonFeature _updateFeature;
        private readonly IDeletePersonFeature _deleteFeature;

        public PeopleController(IListHomeFeature listHomeFeature,
            IPersonDetailFeature detailFeature,
            ICreatePersonFeature createFeature,
            IUpdatePersonFeature updateFeature,
            IDeletePersonFeature deleteFeature)
        {
            _listHomeFeature = listHomeFeature;
            _detailsFeature = detailFeature;
            _createFeature = createFeature;
            _updateFeature = updateFeature;
            _deleteFeature = deleteFeature;
        }

        //public ActionResult Index() => View(_listHomeFeature.Exec().ToList());

        public ActionResult Details(int id) =>
               View(_detailsFeature.Exec(id));

        public ActionResult Create(int homeId) => View(new CreatePersonRequest
        {
            Home = homeId
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            _createFeature.Exec(request);
            return RedirectToAction("Details", "Homes", new { id = request.Home });
        }

        public ActionResult Update(int id) => View(new UpdatePersonRequest { Id = id });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdatePersonRequest request)
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
            _deleteFeature.Exec(new DeletePersonRequest { PersonId = id });
            return RedirectToAction("Index", "Homes");
        }
    }
}