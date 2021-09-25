using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("AdminRole")]
    public class AdminRole
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Admin> Admin { get; set; }
    }
}
