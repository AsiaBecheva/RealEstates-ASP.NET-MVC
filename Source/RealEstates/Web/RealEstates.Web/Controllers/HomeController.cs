namespace RealEstates.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;
    using Data.Common.Repositories;
    using Data.Models;
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models.Home;
    public class HomeController : Controller
    {
        private IHomeService homeService;
        private IDeletableEntityRepository<Property> properties;

        public HomeController(IDeletableEntityRepository<Property> properties,
            IHomeService homeService)
        {
            this.properties = properties;
            this.homeService = homeService;
        }

        //TODO: Uncomment all cache in production
        //[OutputCache(Duration = 60 * 10)]  
        public ActionResult Index()
        {
            return View(this.homeService.GetAllHomeViewModel());
        }

        //[OutputCache(Duration = 60 * 10)]
        public ActionResult Apartments()
        {
            return View(this.homeService.GetHomeViewModel("Apartment"));
        }

        //[OutputCache(Duration = 60 * 10)]
        public ActionResult Offices()
        {
            return View(this.homeService.GetHomeViewModel("Office"));
        }

        //[OutputCache(Duration = 60 * 10)]
        public ActionResult Houses()
        {
            return View(this.homeService.GetHomeViewModel("House"));
        }

        //[OutputCache(Duration = 60 * 10)]
        public ActionResult Hotels()
        {
            return View(this.homeService.GetHomeViewModel("Hotel"));
        }

        //[OutputCache(Duration = 60 * 10)]
        public ActionResult Garages()
        {
            return View(this.homeService.GetHomeViewModel("Garage"));
        }

        //[OutputCache(Duration = 60 * 10)]
        public ActionResult Storages()
        {
            return View(this.homeService.GetHomeViewModel("Storage"));
        }

        //[OutputCache(Duration = 60 * 10)]
        public ActionResult Restaurants()
        {
            return View(this.homeService.GetHomeViewModel("Restaurant"));
        }

        public ActionResult Search(string query)
        {
            var result = this.properties
                .All()
                .Where(p => p.Title.ToLower().Contains(query.ToLower()))
                .ProjectTo<PropertyViewModel>()
                .ToList();

            return PartialView("_PropertyResult", result);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}