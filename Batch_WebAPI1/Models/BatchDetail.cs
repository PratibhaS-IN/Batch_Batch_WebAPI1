using System;
using System.Collections.Generic;

#nullable disable

namespace Batch_WebAPI1.Models
{
    public partial class BatchDetail
    {
        public int BatchId { get; set; }
        public string BusinessUnit { get; set; }
        public string Status { get; set; }
        public DateTime? BatchPublishDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string BatchId1 { get; set; }
    }
}
