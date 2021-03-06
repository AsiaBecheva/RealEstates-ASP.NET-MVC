﻿namespace RealEstates.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;

    public class Property : AuditInfo, IDeletableEntity
    {
        public Property()
        {
            this.CreatedOn = DateTime.Now;
            Page = 1;
            PageSize = 5;
            Sort = this.Id;
            SortDir = "DESC";
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [Required]
        public PropertyStatus PropertyStatus { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        public int Price { get; set; }

        [StringLength(1000)]
        [UIHint("MultilineText")]
        public string Description { get; set; }
        
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
        
        public Sity Sity { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Sort { get; set; }
        public string SortDir { get; set; }
        public int TotalRecords { get; set; }
        public List<Property> Properties { get; set; }
    }
}
