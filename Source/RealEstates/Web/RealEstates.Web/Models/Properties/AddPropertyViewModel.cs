namespace RealEstates.Web.Models.Properties
{
    using RealEstates.Data.Models;
    using RealEstates.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class AddPropertyViewModel : IMapFrom<Property>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Status")]
        [UIHint("Enum")]
        public PropertyStatus PropertyStatus { get; set; }

        [Required]
        [Display(Name = "Type")]
        [UIHint("Enum")]
        public PropertyType PropertyType { get; set; }
        
        //[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public int Price { get; set; }

        [StringLength(1000)]
        [UIHint("MultilineText")]
        public string Description { get; set; }

        [Required]
        [UIHint("Enum")]
        public Sity Sity { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }
    }
}