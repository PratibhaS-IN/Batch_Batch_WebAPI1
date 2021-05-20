using System;
using System.Collections.Generic;

#nullable disable

namespace Batch_WebAPI1.Models
{
    public partial class Attribute
    {
        public int AttrId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string BatchId { get; set; }
    }

    public partial class AttributeShow //view model
    { 
        public string Key { get; set; }
        public string Value { get; set; } 
    }
}
