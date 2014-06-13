using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Adapters.Interfaces;
using WebForum.Data;
using WebForum.Models;

namespace WebForum.Adapters.Adapters
{
    public class BoardAdapter : IBoard
    {
        public BoardVM Get(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            BoardVM board = db.Boards.Where(b => b.Id == id).Select(b => new BoardVM
            {
                Name = b.Name,
                Posts = db.Posts.Where(p => p.BoardId == b.Id).Select(p => new PostVM {
                    Id = p.Id,
                    BoardId = b.Id,
                    Title = p.Title,
                    Author = p.User.Username,
                    Posted = p.Posted
                }).ToList()
            }).FirstOrDefault();
            return board;
        }

        public List<BoardVM> GetBoards()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<BoardVM> boards = db.Boards.Select(b => new BoardVM {
                Id = b.Id,
                Name = b.Name
            }).ToList();
            return boards;
        }
    }
}