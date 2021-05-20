using System;
using System.Collections.Generic;

#nullable disable

namespace Batch_WebAPI1.Models
{
    public partial class File
    {
        public int FId { get; set; }
        public string Filename { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public string Hash { get; set; }
        public string BatchId { get; set; }
    }

    public partial class FileShow
    {
       
        public string Filename { get; set; }
      
        public string FileSize { get; set; }

        public string FileType { get; set; }
        public string Hash { get; set; }
        
    }
}
