using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch_WebAPI1.Models
{
    public class BatchViewModel
    {

        public string BatchId1 { get; set; }
        public string Status { get; set; }

        public List<AttributeShow> attribute { get; set; }

        public string BusinessUnit { get; set; }

        public DateTime? BatchPublishDate { get; set; }



        public DateTime? ExpiryDate { get; set; }

        public List<FileShow> fileShow { get; set; }


       

       
    }
}
