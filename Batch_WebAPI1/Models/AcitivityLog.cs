using System;
using System.Collections.Generic;

#nullable disable

namespace Batch_WebAPI1.Models
{
    public partial class AcitivityLog
    {
        public int LogId { get; set; }
        public string Activity { get; set; }
        public string Status { get; set; }
        public DateTime? ActiityDateTime { get; set; }
        public string BatchId { get; set; }
    }
}
