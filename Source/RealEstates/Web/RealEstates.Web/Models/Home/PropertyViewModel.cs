namespace RealEstates.Web.Models.Home
{
    using Infrastructure.Mapping;
    using RealEstates.Data.Models;
    using System.Collections.Generic;
    public class PropertyViewModel : IMapFrom<Property>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Sity Sity { get; set; }

        public PropertyStatus PropertyStatus { get; set; }

        public PropertyType PropertyType { get; set; }

        public int Price { get; set; }

        public ICollection<File> Files { get; set; }
    }
}