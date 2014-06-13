using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebForum.Adapters.Adapters;
using WebForum.Adapters.Interfaces;
using WebForum.Data.Models;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class apiUserController : ApiController
    {
        private IUser _adapter;

        public apiUserController()
        {
            _adapter = new UserAdapter();
        }

        public IHttpActionResult Get(int id = -1)
        {
            if (id != -1)
            {
                return Ok(_adapter.GetUser(id));
            }
            else
            {
                return Ok(_adapter.GetUsers());
            }
        }

        public IHttpActionResult Post(User user)
        {
            _adapter.CreateUser(user);
            return Ok();
        }

        public IHttpActionResult Put(User user)
        {
            _adapter.UpdateUser(user);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            _adapter.DeleteUser(id);
            return Ok();
        }
    }
}