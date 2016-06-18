namespace RealEstates.Web.Controllers
{
    using Data.Common.Repositories;
    using Data.Models;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models.Properties;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using System;

    public class PropertiesController : Controller
    {
        private IDeletableEntityRepository<Property> modifiableProperties;
        private IRepository<Property> realDeleteProperties;
        private IDeletableEntityRepository<User> users;

        public PropertiesController(IDeletableEntityRepository<Property> modifiableProperties, 
            IDeletableEntityRepository<User> users,
            IRepository<Property> realDeleteProperties)
        {
            this.modifiableProperties = modifiableProperties;
            this.users = users;
            this.realDeleteProperties = realDeleteProperties;
        }

        public ActionResult Details(int id)
        {
            var property = modifiableProperties
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
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    Description = model.Description,
                    Sity = model.Sity,
                    Price = model.Price,
                    PropertyStatus = model.PropertyStatus,
                    PropertyType = model.PropertyType
                };

                this.modifiableProperties.Add(property);
                this.modifiableProperties.SaveChanges();

                return RedirectToAction("MyAds", "Properties");
            }

            return View(model);
        }

        [Authorize]
        public ActionResult UpdateToInactive(int id)
        {
            var updateAd = this.modifiableProperties.GetById(id);
            if (updateAd == null)
            {
                return this.HttpNotFound("There is no ad with such ID!");
            }

            if (updateAd.IsDeleted == true)
            {
                return this.Content("This Ad is already inactive!");
            }
            else
            {
                updateAd.IsDeleted = true;
                updateAd.ModifiedOn = DateTime.Now;
                modifiableProperties.SaveChanges();

                return RedirectToAction("MyAds");
            }
        }

        [Authorize]
        public ActionResult UpdateToActive(int id)
        {
            var updateAd = this.modifiableProperties.GetById(id);
            if (updateAd == null)
            {
                return this.HttpNotFound("There is no ad with such ID!");
            }

            if (updateAd.IsDeleted == false)
            {
                return this.Content("This Ad is active!");
            }
            else
            {
                updateAd.IsDeleted = false;
                updateAd.ModifiedOn = DateTime.Now;
                modifiableProperties.SaveChanges();

                return RedirectToAction("MyAds");
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var deleteAd = this.realDeleteProperties.GetById(id);

            if (deleteAd == null)
            {
                return this.HttpNotFound("There is no ad with such ID!");
            }
            else
            {
                realDeleteProperties.Delete(deleteAd);
                realDeleteProperties.SaveChanges();

                return RedirectToAction("MyAds");
            }
        }

        public ActionResult MyAds()
        {
            var currentUser = this.User.Identity.GetUserId();
            var myAds = this.realDeleteProperties
                .All()
                .Where(x => x.AuthorId == currentUser)
                .ProjectTo<MyAdsViewModel>()
                .ToList();

            return View(myAds);
        }
    }
}
