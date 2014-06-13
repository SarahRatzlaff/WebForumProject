namespace WebForum.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebForum.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebForum.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebForum.Data.ApplicationDbContext context)
        {
            //Create User Accounts if they do not exist.
            User Admin = context.Users.Where(u => u.Username == "Admin").FirstOrDefault();
            User User1 = context.Users.Where(u => u.Username == "User1").FirstOrDefault();
            User User2 = context.Users.Where(u => u.Username == "User2").FirstOrDefault();
            User User3 = context.Users.Where(u => u.Username == "User3").FirstOrDefault();

            if (Admin == null)
            {
                Admin = new User { Username = "Admin", Password = "123456", isActive = true };
                context.Users.Add(Admin);
            }
            if (User1 == null)
            {
                User1 = new User { Username = "User1", Password = "123456", isActive = true };
                context.Users.Add(User1);
            }
            if (User2 == null)
            {
                User2 = new User { Username = "User2", Password = "123456", isActive = true };
                context.Users.Add(User2);
            }
            if (User3 == null)
            {
                User3 = new User { Username = "User3", Password = "123456", isActive = true };
                context.Users.Add(User3);
            }

            context.SaveChanges();
            //Create Boards
            context.Boards.AddOrUpdate(b => b.Name,
                new Board { Name = "General Board" },
                new Board { Name = "Help Board" },
                new Board { Name = "Spam Board" });

            context.SaveChanges();

            //Create Posts
            var PostCount = 0;
            for (int i = 1; i < 4; i++){
            context.Posts.AddOrUpdate(p => p.Id,
                new Post { Id = 1 * i, BoardId = i, UserId = User1.Id, Title = "Post 1", Body = "This is my post.", Posted = (DateTime.Now) },
                new Post { Id = 2 * i, BoardId = i, UserId = User2.Id, Title = "Post 2", Body = "This is my post.", Posted = (DateTime.Now) },
                new Post { Id = 3 * i, BoardId = i, UserId = User3.Id, Title = "Post 3", Body = "This is my post.", Posted = (DateTime.Now) },
                new Post { Id = 4 * i, BoardId = i, UserId = User1.Id, Title = "Post 4", Body = "This is my post.", Posted = (DateTime.Now) },
                new Post { Id = 5 * i, BoardId = i, UserId = User2.Id, Title = "Post 5", Body = "This is my post.", Posted = (DateTime.Now) },
                new Post { Id = 6 * i, BoardId = i, UserId = User3.Id, Title = "Post 6", Body = "This is my post.", Posted = (DateTime.Now) }
                );
            PostCount += 6;
                }
            context.SaveChanges();

            //Create Comments
            for (int i = 1; i < PostCount + 1; i++) {
                context.Comments.AddOrUpdate(c => c.Id,
                    new Comment { Id = 1 * i, PostId = i, UserId = User1.Id, Body = "Comment", Posted = (DateTime.Now) },
                    new Comment { Id = 2 * i, PostId = i, UserId = User2.Id, Body = "Comment", Posted = (DateTime.Now) },
                    new Comment { Id = 3 * i, PostId = i, UserId = User3.Id, Body = "Comment", Posted = (DateTime.Now) },
                    new Comment { Id = 4 * i, PostId = i, UserId = User1.Id, Body = "Comment", Posted = (DateTime.Now) },
                    new Comment { Id = 5 * i, PostId = i, UserId = User2.Id, Body = "Comment", Posted = (DateTime.Now) },
                    new Comment { Id = 6 * i, PostId = i, UserId = User3.Id, Body = "Comment", Posted = (DateTime.Now) }
                    );
            }
            context.SaveChanges();
        }
    }
}
