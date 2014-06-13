using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForum.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public int FromId { get; set; }
        [ForeignKey("FromId")]
        public User From { get; set; }
        [Required]
        public int ToId { get; set; }
        [ForeignKey("ToId")]
        public User To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
