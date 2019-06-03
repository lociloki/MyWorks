using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataDemo.Common.Helpers;
using ODataDemo.Common.Models;

namespace ODataDemo.Controllers.Odata
{
    [Produces("application/json")]
    [ODataRoutePrefix("Users")]
    public class UserController : ODataController
    {
        private readonly DataContext context;
        public UserController(DataContext context) => this.context = context;

        [HttpGet]
        [ODataRoute]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 2)]
        public ActionResult<IQueryable<User>> Get()
        {
            return Ok(context.Users.AsQueryable());
        }


        [HttpGet]
        [ODataRoute("({key})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 2)]
        public ActionResult<IQueryable<User>> Get([FromODataUri] int key)
        {
            return Ok(context.Users.Find(key));
        }
    }
}
