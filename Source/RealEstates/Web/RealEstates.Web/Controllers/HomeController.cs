using AutoMapper.QueryableExtensions;
using RealEstates.Data.Common.Repositories;
using RealEstates.Data.Models;
using RealEstates.Web.Models;
using System.Web.Mvc;

namespace RealEstates.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDeletableEntityRepository<Property> properties;

        public HomeController(IDeletableEntityRepository<Property> properties)
        {
            this.properties = properties;
        }

        public ActionResult Index()
        {
            var posts = this.properties.All().ProjectTo<PropertyViewModel>();
            return View(posts);
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