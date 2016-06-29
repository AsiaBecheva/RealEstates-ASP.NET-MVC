namespace RealEstates.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using RealEstates.Data.Models;
    using Data.Common.Repositories;
    using Services.Contracts;
    using Data.Common;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class PropertiesAdminController : Controller
    {
        private IRepository<Property> properties;
        private IPropertyService propertyService;

        public PropertiesAdminController(IRepository<Property> properties, IPropertyService propertyService)
        {
            this.properties = properties;
            this.propertyService = propertyService;
        }

        
        public ActionResult Index()
        {
            var allProperties = properties.All().ToList();

            return View(allProperties);
        }
        

        public ActionResult Details(int id)
        {
            var property = this.propertyService.PropertyDetails(id);

            return View(property);
        }

        
        public ActionResult Edit(int id)
        {
            Property property = properties.GetById(id);
            if (property == null)
            {
                return HttpNotFound();
            }

            return View(property);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Property property)
        {
            if (ModelState.IsValid)
            {
                properties.Update(property);
                properties.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(property);
        }


        public ActionResult Delete(int id)
        {
            var deleteAd = this.properties.GetById(id);

            properties.Delete(deleteAd);
            properties.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
