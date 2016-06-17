namespace RealEstates.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    public class Property : AuditInfo, IDeletableEntity
    {
        private ICollection<Image> images;

        public Property()
        {
            this.images = new HashSet<Image>();
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public PropertyStatus PropertyStatus { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
        
        public Sity Sity { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
