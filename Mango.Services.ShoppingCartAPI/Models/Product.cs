using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCartAPI.Models
{
    public class Product
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        [Required]
        public String Name { get; set; }

        [Range(1, 1000)]
        public Double Price { get; set; }

        public String Description { get; set; }
        public String CategoryName { get; set; }
        public String ImageUrl { get; set; }

    }
}
