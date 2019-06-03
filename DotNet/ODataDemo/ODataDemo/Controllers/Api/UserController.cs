using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataDemo.Common.Helpers;
using ODataDemo.Common.Models;

namespace ODataDemo.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;
        public UserController(DataContext context) => this.context = context;

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(context.Users.AsEnumerable());
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<User>> Get(string id)
        {
            return Ok(context.Users.Find(id));
        }
    }
}
