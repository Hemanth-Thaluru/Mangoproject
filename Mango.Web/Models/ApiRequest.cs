using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Mango.Web.SD;

namespace Mango.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public String Url { get; set; }
        public object Data { get; set; }
        public String AccessToken { get; set; }
    }
}
