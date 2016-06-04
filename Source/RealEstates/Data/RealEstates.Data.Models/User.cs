namespace RealEstates.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Apartment> apartments;
        private ICollection<Office> offices;
        private ICollection<Restaurant> restaurants;
        private ICollection<Garage> garages;

        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.apartments = new HashSet<Apartment>();
            this.restaurants = new HashSet<Restaurant>();
            this.garages = new HashSet<Garage>();
        }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public virtual ICollection<Apartment> Apartments
        {
            get { return this.apartments; }
            set { this.apartments = value; }
        }

        public virtual ICollection<Office> Offices
        {
            get { return this.offices; }
            set { this.offices = value; }
        }

        public virtual ICollection<Restaurant> Restaurants
        {
            get { return this.restaurants; }
            set { this.restaurants = value; }
        }

        public virtual ICollection<Garage> Garages
        {
            get { return this.garages; }
            set { this.garages = value; }
        }
    }
}
