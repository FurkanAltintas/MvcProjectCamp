using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Message")]
    public class Message : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        public string Messages { get; set; }
        public bool IsRead { get; set; } //okundu
        public bool IsStar { get; set; } //önemli
        public bool IsSend { get; set; } //gönderilen
        public bool IsDraft { get; set; } //taslak
        public bool IsTrash { get; set; } //çöp

        //BaseEntity kısmında ki IsActive okundu okunmadı olucak
    }
}
