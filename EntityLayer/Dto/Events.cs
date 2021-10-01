using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityLayer.Dto
{
    public class Events
    {
        public string title { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
    }
}