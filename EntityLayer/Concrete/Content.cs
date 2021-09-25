using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Content")]
    public class Content : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int HeadingId { get; set; }
        [ForeignKey("HeadingId")]
        public virtual Heading Heading { get; set; }
        public int? WriterId { get; set; }
        [ForeignKey("WriterId")]
        public virtual Writer Writer { get; set; }
        [StringLength(1000)]
        public string Value { get; set; }
    }
}
