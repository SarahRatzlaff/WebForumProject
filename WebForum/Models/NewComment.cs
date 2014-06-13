using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForum.Models
{
    public class NewComment
    {
        public int PostId { get; set; }
        public int CommentId { get; set; } // This is only needed when updating the Comment, not when posting. 
        public string Body { get; set; }
        public int AuthorId { get; set; }
    }
}