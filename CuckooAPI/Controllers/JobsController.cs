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

    public class JobsController : ApiController
    {
        private Jobs j =  new Jobs();

        // GET: api/Jobs
        public async Task<List<Jobs>> Get()
        {
            return await j.GetAllJobs();
        }

        // GET: api/Jobs/5
        public async Task<Jobs> Get(string id)
        {
           
            return await j.GetJobById(id);
        }

        // POST: api/Jobs
        public async Task<Jobs> Post(Jobs jobsModel)
        {
            return await j.AddNewJob(jobsModel);
        }

        // PUT: api/Jobs/5
        public async Task<Jobs> Put(string id, Jobs jobModel)
        {
            return await j.UpdateJob(id, jobModel);
        }

        // DELETE: api/Jobs/5
        public async Task<IHttpActionResult> Delete(string id)
        {
            await j.DeleteJob(id);
            return Ok();
        }
    }
}
