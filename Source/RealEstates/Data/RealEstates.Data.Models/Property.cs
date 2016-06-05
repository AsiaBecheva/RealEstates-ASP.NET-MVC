namespace RealEstates.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Property : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public PropertyStatus PropertyStatus { get; set; }

        public PropertyType PropertyType { get; set; }

        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [DefaultValue(Sity.All)]
        public Sity Sity { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
