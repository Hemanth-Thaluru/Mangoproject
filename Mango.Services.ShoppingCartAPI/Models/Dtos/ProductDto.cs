using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCartAPI.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public String Description { get; set; }
        public String CategoryName { get; set; }
        public String ImageUrl { get; set; }
    }
}
