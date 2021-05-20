using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch_WebAPI1.Models
{
    public class VwModel
    {
        public string BusinessUnit { get; set; }
       // public string Status { get; set; }

       

        public AclShow acl { get; set; }


        public List<AttributeShow> attribute { get; set; }
        public DateTime? ExpiryDate { get; set; }

     

    }

}
