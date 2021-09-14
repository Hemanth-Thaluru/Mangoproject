using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public Object Result { get; set; }
        public String DisplayMessage { get; set; } = "";
        public List<String> Errormessages { get; set; }

    }
}
