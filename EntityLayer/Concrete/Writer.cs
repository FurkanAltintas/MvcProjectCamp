using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Writer")]
    public class Writer : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SurName { get; set; }
        public virtual string FullName => Name + " " + SurName;
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string About { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public ICollection<Heading> Heading { get; set; }
        public ICollection<Content> Content { get; set; }
    }
}
