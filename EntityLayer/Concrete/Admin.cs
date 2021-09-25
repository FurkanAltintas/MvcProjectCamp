using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public int AdminRoleId { get; set; }
        [ForeignKey("AdminRoleId")]
        public virtual AdminRole AdminRole { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(150)]
        public string Profile { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(75)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }    
        public ICollection<Ability> Ability { get; set; }
    }
}
