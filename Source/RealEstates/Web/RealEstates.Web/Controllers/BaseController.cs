namespace RealEstates.Web.Controllers
{
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}