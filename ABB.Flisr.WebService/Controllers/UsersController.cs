using ABB.Flisr.FakeServices;
using ABB.Flisr.FakeServices.Fakers;
using ABB.Flisr.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ABB.Flisr.WebService.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;

        public UsersController()
            : this(new FakeUsersService(new UserFaker()))
        {

        }

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var users = usersService.Get();

            return Ok(users);

            
        }

        // https://docs.microsoft.com/pl-pl/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var user = usersService.Get(id);

            if (user==null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("{firstname}")]
        public IHttpActionResult Get(string firstname)
        {
            return Ok();
        }

        [HttpGet]
        [Route("~/api/networks/{networkId}/users")]
        public IHttpActionResult GetUsersByNetwork(int networkId)
        {
            return Ok();
        }
    }
}