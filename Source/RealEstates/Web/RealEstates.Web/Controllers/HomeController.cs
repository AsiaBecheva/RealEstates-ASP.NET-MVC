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
    using Infrastructure.Mapping;
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

        public ActionResult Search(string query)
        {
            var result = this.properties
                .All()
                .Where(p => p.Title.ToLower().Contains(query.ToLower()))
                .To<PropertyViewModel>()
                .ToList();

            return PartialView("_PropertyResult", result);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}