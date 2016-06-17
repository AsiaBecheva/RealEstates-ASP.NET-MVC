namespace RealEstates.Web.Controllers
{
    using Data.Common.Repositories;
    using Data.Models;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models.Properties;
    using System.Web;
    public class PropertiesController : Controller
    {
        private IDeletableEntityRepository<Property> properties;

        public PropertiesController(IDeletableEntityRepository<Property> properties)
        {
            this.properties = properties;
        }

        public ActionResult Details(int id)
        {
            var property = properties
                .All()
                .Where(pr => pr.Id == id)
                .ProjectTo<PropertyDetailsViewModel>()
                .FirstOrDefault();

            if (property == null)
            {
                throw new HttpException(404, "Property not Found!");
            }

            return View(property);
        }

        public ActionResult Add(AddPropertyViewModel model)
        {
            var addPropertyViewModel = new AddPropertyViewModel()
            {

            };

            return View(addPropertyViewModel);
        }
    }
}