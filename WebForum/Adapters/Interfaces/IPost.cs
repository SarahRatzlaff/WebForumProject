using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Adapters.Interfaces
{
    public interface IPost
    {
        PostVM GetPost(int id);
        void CreatePost(NewPost post);
        void UpdatePost(NewPost post);
        void DeletePost(int id);
    }
}
