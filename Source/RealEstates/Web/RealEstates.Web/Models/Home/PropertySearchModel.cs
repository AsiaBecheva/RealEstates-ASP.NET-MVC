using RealEstates.Data.Models;
using RealEstates.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Web.Models.Home
{
    public class PropertySearchModel : IMapFrom<Property>
    {
        public PropertySearchModel()
        {
            Page = 1;
            PageSize = 5;
            Sort = this.Id;
            SortDir = "DESC";
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public PropertyStatus PropertyStatus { get; set; }

        public PropertyType PropertyType { get; set; }

        [Display(Name = "Price (Max.)")]
        public int Price { get; set; }

        public Sity Sity { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Sort { get; set; }
        public string SortDir { get; set; }
        public int TotalRecords { get; set; }
        public List<Property> Properties { get; set; }
    }
}