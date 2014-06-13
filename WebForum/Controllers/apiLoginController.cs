using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebForum.Adapters.Adapters;
using WebForum.Adapters.Interfaces;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class apiLoginController : ApiController
    {
        private IUser _adapter;
        
        public apiLoginController(){
            _adapter = new UserAdapter(); 
        }

        public IHttpActionResult Post(LoginRequest request)
        {
            LoggedIn loggedIn = _adapter.LoginVerify(request);
            if (loggedIn != null)
                return Ok(loggedIn);
            else
                return Unauthorized();
        }
    }
}