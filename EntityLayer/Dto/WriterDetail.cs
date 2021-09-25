using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace EntityLayer.Dto
{
    public class WriterDetail
    {
        public Writer Writer { get; set; }
        public IEnumerable<Content> Content { get; set; }
    }
}
