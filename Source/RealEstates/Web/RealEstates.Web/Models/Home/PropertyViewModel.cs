namespace RealEstates.Web.Models.Home
{
    using Infrastructure.Mapping;
    using RealEstates.Data.Models;

    public class PropertyViewModel : IMapFrom<Property>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Sity Sity { get; set; }

        public string Description { get; set; }

        public PropertyStatus PropertyStatus { get; set; }

        public PropertyType PropertyType { get; set; }

        public decimal Price { get; set; }
    }
}