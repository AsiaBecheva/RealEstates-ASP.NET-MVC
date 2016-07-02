namespace RealEstates.Web.Services
{
    using Data.Common.Repositories;
    using Data.Models;
    using Models.Home;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Infrastructure.Mapping;
    public class HomeService : IHomeService
    {
        private IDeletableEntityRepository<Property> properties;

        public HomeService(IDeletableEntityRepository<Property> properties)
        {
            this.properties = properties;
        }

        public IList<PropertyViewModel> GetHomeViewModel(string property)
        {
            var homeViewModel = properties
                .All()
                .Where(x => x.PropertyType.ToString() == property && x.IsDeleted == false)
                .OrderByDescending(p => p.CreatedOn)
                .Take(25)
                .To<PropertyViewModel>()
                .ToList();

            return homeViewModel;
        }

        public IList<PropertyViewModel> GetAllHomeViewModel()
        {
            var homeViewModel = this.properties
                .All()
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(p => p.CreatedOn)
                .Take(25)
                .To<PropertyViewModel>()
                .ToList();

            return homeViewModel;
        }
    }
}