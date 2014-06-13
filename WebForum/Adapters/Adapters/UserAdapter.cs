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
    public class UserAdapter : IUser
    {
        public LoggedIn LoginVerify(LoginRequest request)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.Username == request.Username).FirstOrDefault();
            if (user == null || user.Username != request.Username || user.Password != request.Password)
            {
                LoggedIn log = null;
                return log;
            }
            else
            {
                LoggedIn log = db.Users.Where(u => u.Username == request.Username).Select(l => new LoggedIn { 
                    Id = l.Id,
                    Username = l.Username
                }).FirstOrDefault();
                return log;
            }
        }

        public List<UserVM> GetUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<UserVM> Users = db.Users.Where(u => u.isActive == true).Select(
                u => new UserVM { 
                    Username = u.Username,
                    Id = u.Id
                }).ToList();
            return Users;
        }

        public UserVM GetUser(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserVM user = db.Users.Where(u => u.isActive == true).Where(u => u.Id == id).Select(
                u => new UserVM
                {
                    Username = u.Username,
                    Id = u.Id
                }).FirstOrDefault();
            return user;
        }

        public void CreateUser(User user)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            user.isActive = true;
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            user.isActive = false;
            db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User dbUser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            dbUser.Username = user.Username;
            dbUser.Password = user.Password;
            db.SaveChanges();
        }
    }
}