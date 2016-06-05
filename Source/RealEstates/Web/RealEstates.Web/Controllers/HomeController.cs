using AutoMapper.QueryableExtensions;
using RealEstates.Data.Common.Repositories;
using RealEstates.Data.Models;
using RealEstates.Web.Models;
namespace RealEstates.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        private IDeletableEntityRepository<Property> properties;

        public HomeController(IDeletableEntityRepository<Property> properties)
        {
            this.properties = properties;
        }

        public ActionResult Index()
        {
            var properties = this.properties
                .All()
                .OrderBy(p => p.CreatedOn)
                .Take(10)
                .ProjectTo<PropertyViewModel>()
                .ToList();

            return View(properties);
        }

        public ActionResult Apartments()
        {
            return null;
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