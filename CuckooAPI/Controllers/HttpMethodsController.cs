using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CuckooCommon;

namespace CuckooAPI.Controllers
{
            [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]

    public class HttpMethodsController : ApiController
    {
        // GET: api/HttpMethods
        public IHttpActionResult Get()
        {
            Dictionary<int, string> methods = new Dictionary<int, string>();

            foreach (HttpMethods item in Enum.GetValues(typeof(CuckooCommon.HttpMethods)))
            {
                methods.Add((int)item, item.ToString());
            }

            return Ok(methods);
        }
    }
}
