namespace RealEstates.Web.Models.Properties
{
    using Infrastructure.Mapping;
    using RealEstates.Data.Models;
    using System.Collections.Generic;
    public class MyAdsViewModel : IMapFrom<Property>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public PropertyStatus PropertyStatus { get; set; }
        
        public PropertyType PropertyType { get; set; }

        public Sity Sity { get; set; }

        public string Description { get; set; }

        public ICollection<File> Files { get; set; }
    }
}