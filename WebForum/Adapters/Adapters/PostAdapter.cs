using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Adapters.Interfaces;
using WebForum.Data;
using WebForum.Models;

namespace WebForum.Adapters.Adapters
{
    public class PostAdapter : IPost
    {
        public PostVM GetPost(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            PostVM post = db.Posts.Where(p => p.Id == id).Select(p => new PostVM
            {
                Id = id,
                BoardId = p.BoardId,
                Body = p.Body,
                Author = p.User.Username,
                Title = p.Title,
                Comments = db.Comments.Where(c => c.PostId == p.Id).Select(c => new CommentVM { 
                    Author = c.User.Username,
                    Body = c.Body,
                    Id = c.Id
                }).ToList(),
                Posted = p.Posted
            }).FirstOrDefault();
            return post;
        }

        public void CreatePost(NewPost post)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(NewPost post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            throw new NotImplementedException();
        }
    }
}