using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Heading")]
    public class Heading : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int WriterId { get; set; }
        [ForeignKey("WriterId")]
        public virtual Writer Writer { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Content> Content { get; set; }
    }
}
