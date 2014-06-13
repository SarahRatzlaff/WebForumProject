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
    public class apiPostController : ApiController
    {
        private IPost _adapter;

        public apiPostController()
        {
            _adapter = new PostAdapter();
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_adapter.GetPost(id));
        }

        public IHttpActionResult Post(NewPost post)
        {
            _adapter.CreatePost(post);
            return Ok();
        }

        public IHttpActionResult Put(NewPost post)
        {
            _adapter.UpdatePost(post);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            _adapter.DeletePost(id);
            return Ok();
        }
    }
}
