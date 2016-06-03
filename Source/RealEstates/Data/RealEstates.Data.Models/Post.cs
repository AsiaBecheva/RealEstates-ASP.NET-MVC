
using RealEstates.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Data.Models
{
    public class Post : AuditInfo, IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
