using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Image")]
    public class Image : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ImageCategoryId { get; set; }
        [ForeignKey("ImageCategoryId")]
        public virtual ImageCategory ImageCategory { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Url { get; set; }
    }
}
