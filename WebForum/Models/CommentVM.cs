using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForum.Models
{
    public class CommentVM
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
    }
}