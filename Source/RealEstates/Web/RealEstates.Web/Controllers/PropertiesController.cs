namespace RealEstates.Web.Controllers
{
    using Data.Common.Repositories;
    using Data.Models;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models.Properties;
    using System.Web;
    using AutoMapper;

    public class PropertiesController : Controller
    {
        private IDeletableEntityRepository<Property> properties;
        private IDeletableEntityRepository<User> users;

        public PropertiesController(IDeletableEntityRepository<Property> properties, IDeletableEntityRepository<User> users)
        {
            this.properties = properties;
            this.users = users;
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

        [Authorize]
        public ActionResult Add(AddPropertyViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var property = new Property()
                {
                    Id = model.Id,
                    //Author = this.users.All().Where(u => u.UserName == HttpContext.User.Identity.Name).FirstOrDefault(),
                    Title = model.Title,
                    Description = model.Description,
                    Sity = model.Sity,
                    Price = model.Price,
                    PropertyStatus = model.PropertyStatus,
                    PropertyType = model.PropertyType
                };
                properties.Add(property);
                properties.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}