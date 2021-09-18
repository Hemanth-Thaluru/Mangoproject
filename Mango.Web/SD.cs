using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web
{
    public static class SD
    {
        public static String ProductAPIBase { get; set; }
        public static String ShoppingCartAPIBase { get; set; }
        public static String CouponAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
