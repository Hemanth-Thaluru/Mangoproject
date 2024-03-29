﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Models
{
    public class ProductDto
    {
        public ProductDto()
        {
            Count = 1;
        }

        public int ProductId { get; set; }
     
        public String Name { get; set; }
        public Double Price { get; set; }

        public String Description { get; set; }
        public String CategoryName { get; set; }
        public String ImageUrl { get; set; }

        [Range(1,100)]
        public int Count { get; set; }
    }
}
