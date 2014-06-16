using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Adapters.Interfaces;
using WebForum.Data;
using WebForum.Data.Models;
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
                Comments = db.Comments.Where(c => c.PostId == p.Id).Select(c => new CommentVM
                {
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
            ApplicationDbContext db = new ApplicationDbContext();
            Post myPost = new Post();
            myPost.UserId = 4;
            myPost.BoardId = 1;
            myPost.Title = post.Title;
            myPost.Body = post.Body;
            myPost.Posted = System.DateTime.Now;
            db.Posts.Add(myPost);
            db.SaveChanges();
        }



        //public int Id { get; set; }
        //public int BoardId { get; set; }
        //public string Title { get; set; }
        //public string Body { get; set; }
        //public DateTime Posted { get; set; }
        //[Required]
        //public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public User User { get; set; }
        //public virtual List<Comment> Comments { get; set; }


        public void UpdatePost(NewPost post)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Comment> Comments = db.Comments.Where(c => c.PostId == id).ToList();
            foreach (Comment comment in Comments)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
            }
            Post myPost = new Post();
            myPost = db.Posts.Where(p => p.Id == id).FirstOrDefault();
            db.Posts.Remove(myPost);
            db.SaveChanges();
        }
    }
}