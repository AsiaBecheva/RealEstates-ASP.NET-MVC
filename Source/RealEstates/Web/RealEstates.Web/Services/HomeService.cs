namespace RealEstates.Web.Services
{
    using Data.Common.Repositories;
    using Data.Models;
    using Models.Home;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;

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
                .Where(x => x.PropertyType.ToString() == property)
                .OrderBy(p => p.CreatedOn)
                .Take(15)
                .ProjectTo<PropertyViewModel>()
                .ToList();

            return homeViewModel;
        }

        public IList<PropertyViewModel> GetAllHomeViewModel()
        {
            var homeViewModel = this.properties
                .All()
                .OrderBy(p => p.CreatedOn)
                .Take(15)
                .ProjectTo<PropertyViewModel>()
                .ToList();

            return homeViewModel;
        }
    }
}