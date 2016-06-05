namespace RealEstates.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;
    using Data.Common.Repositories;
    using Data.Models;

    public class HomeController : Controller
    {
        private IHomeService homeService;
        private IDeletableEntityRepository<Property> properties;

        public HomeController(IDeletableEntityRepository<Property> properties, IHomeService homeService)
        {
            this.properties = properties;
            this.homeService = homeService;
        }

        public ActionResult Index()
        {
            return View(this.homeService.GetAllHomeViewModel());
        }

        public ActionResult Apartments()
        {
            return View(this.homeService.GetHomeViewModel("Apartment"));
        }

        public ActionResult Offices()
        {
            return View(this.homeService.GetHomeViewModel("Office"));
        }

        public ActionResult Houses()
        {
            return View(this.homeService.GetHomeViewModel("House"));
        }

        public ActionResult Shops()
        {
            return View(this.homeService.GetHomeViewModel("Shop"));
        }

        public ActionResult Hotels()
        {
            return View(this.homeService.GetHomeViewModel("Hotel"));
        }

        public ActionResult Garages()
        {
            return View(this.homeService.GetHomeViewModel("Garage"));
        }

        public ActionResult Storages()
        {
            return View(this.homeService.GetHomeViewModel("Storage"));
        }

        public ActionResult Restaurants()
        {
            return View(this.homeService.GetHomeViewModel("Restaurant"));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}