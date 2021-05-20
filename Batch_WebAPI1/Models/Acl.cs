using System;
using System.Collections.Generic;

#nullable disable

namespace Batch_WebAPI1.Models
{
    public partial class Acl
    {
        public int AclId { get; set; }
        public string ReadUsers { get; set; }
        public string ReadGroups { get; set; }
        public string BatchId { get; set; }

       
    }

    public partial class AclShow
    {
        public List<string> ReadUsers { get; set; }
        public List<string> ReadGroups { get; set; } 

     
    }
}
