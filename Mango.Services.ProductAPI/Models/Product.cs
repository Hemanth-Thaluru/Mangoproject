using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public String Name { get; set; }

        [Range(1,1000)]
        public Double Price { get; set; }

        public String  Description { get; set; }
        public String CategoryName { get; set; }
        public String ImageUrl  { get; set; }

    }
}
