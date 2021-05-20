using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch_WebAPI1.Models
{
    public class ErrorMsgClass
    {
        public string CorrelationID { get; set; }       

        public Errors errors { get; set; }
    }
}
 