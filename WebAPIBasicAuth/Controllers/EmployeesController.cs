using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebAPIBasicAuth.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpGet]
        [BasicAuthentication]
        public HttpResponseMessage Get()
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;

            using(testEntities entities = new testEntities())
            {
               if (userName != "")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entities.EmployeeLists.Select(x=>x.EmpName).ToList());
                }
               else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}
