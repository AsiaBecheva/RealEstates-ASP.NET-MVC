namespace RealEstates.Web.Controllers
{
    using Data.Common.Repositories;
    using Data.Models;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Models.Properties;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web;
    using System.Collections.Generic;
    using Services.Contracts;
    public class PropertiesController : Controller
    {
        private IDeletableEntityRepository<Property> modifiableProperties;
        private IRepository<Property> realDeleteProperties;
        private IDeletableEntityRepository<User> users;
        private IPropertyService propertyService;

        public PropertiesController(IDeletableEntityRepository<Property> modifiableProperties, 
            IDeletableEntityRepository<User> users,
            IRepository<Property> realDeleteProperties,
            IPropertyService propertyService)
        {
            this.modifiableProperties = modifiableProperties;
            this.users = users;
            this.realDeleteProperties = realDeleteProperties;
            this.propertyService = propertyService;
        }

        public ActionResult Details(int id)
        {
            var property = this.propertyService.PropertyDetails(id);

            if (property == null)
            {
                return this.Content("You can see details on only active properties");
            }

            return View(property);
        }

        [Authorize]
        public ActionResult Add(AddPropertyViewModel model, HttpPostedFileBase upload)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUser = this.User.Identity.GetUserId();
                var property = this.propertyService.CreateProperty(model, currentUser);

                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    property.Files = new List<File> { avatar };
                }

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
                return View("ViewInactive");
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
                return View("ViewActive");
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
        public ActionResult Edit(int id)
        {
            var currentUser = this.User.Identity.GetUserId();
            var currentProperty = this.modifiableProperties.GetById(id).AuthorId == currentUser;

            if (currentProperty == false)
            {
                return HttpNotFound();
            }
            else
            {
                var property = this.modifiableProperties.GetById(id);
                return View(property);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Property model, HttpPostedFileBase upload)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUser = this.User.Identity.GetUserId();
                var property = this.propertyService.CreateProperty(model, currentUser);
                
                //TODO: fix this
                //if (upload != null && upload.ContentLength > 0)
                //{
                //    if (property.Files.Any(f => f.FileType == FileType.Avatar))
                //    {
                //        property.Files.Remove(property.Files.First(f => f.FileType == FileType.Avatar));
                //    }
                //    var avatar = new File
                //    {
                //        FileName = System.IO.Path.GetFileName(upload.FileName),
                //        FileType = FileType.Avatar,
                //        ContentType = upload.ContentType
                //    };
                //    var reader = new System.IO.BinaryReader(upload.InputStream);
                //    
                //    avatar.Content = reader.ReadBytes(upload.ContentLength);
                //    
                //    property.Files = new List<File> { avatar };
                //}

                this.modifiableProperties.Update(property);
                this.modifiableProperties.SaveChanges();

                return RedirectToAction("MyAds", "Properties");
            }

            return View(model);
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

        [Authorize]
        public ActionResult MyAds()
        {
            var currentUser = this.User.Identity.GetUserId();
            var myAds = this.propertyService.GetMyAds(currentUser);

            return View(myAds);
        }
    }
}
