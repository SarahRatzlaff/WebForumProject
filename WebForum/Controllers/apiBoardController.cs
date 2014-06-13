using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebForum.Adapters.Adapters;
using WebForum.Adapters.Interfaces;

namespace WebForum.Controllers
{
    public class apiBoardController : ApiController
    {
        private IBoard _adapter;
        public apiBoardController()
        {
            _adapter = new BoardAdapter();
        }
        public IHttpActionResult Get(int id = -1)
        {
            if (id != -1)
            {
                return Ok(_adapter.Get(id));
            }
            else
            {
                return Ok(_adapter.GetBoards());
            }
        }
    }
}