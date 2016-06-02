namespace RealEstates.Data.Models
{
    using System.Collections.Generic;

    public class Property
    {
        private ICollection<Image> images;

        public Property()
        {
            this.images = new HashSet<Image>();
        }

        public int Id { get; set; }

        public PropertyStatus PropertyStatus { get; set; }

        public PropertyType PropertyType { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public Sity Sity { get; set; }
    }
}
