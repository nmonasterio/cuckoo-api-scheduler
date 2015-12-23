using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using CuckooCommon;

namespace CuckooAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class EndpointTesterController : ApiController
    {


        // POST: api/EndpointTester
        public async Task<EndpointTester> Post(Jobs testJob)
        {
            var api = new ApiClient(testJob);

            try
            {
                await api.SendRequest();
                return new EndpointTester(true, 200);
            }

            catch (EndpointException ex)
            {
                return new EndpointTester(false, ex.StatusCode, ex.Message);
            }

        }

    }
}
