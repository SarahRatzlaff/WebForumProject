using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Data.Models;
using WebForum.Models;

namespace WebForum.Adapters.Interfaces
{
    public interface IUser
    {
        LoggedIn LoginVerify(LoginRequest request);
        List<UserVM> GetUsers();
        UserVM GetUser(int id);
        void CreateUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
    }
}
