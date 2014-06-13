using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Adapters.Interfaces
{
    public interface IBoard
    {
        BoardVM Get(int id);
        List<BoardVM> GetBoards();
    }
}
