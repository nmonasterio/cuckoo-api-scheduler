using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CuckooCommon;

namespace CuckooAPI.Controllers
{
    public class IntervalsController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            Dictionary<int, string> intervals = new Dictionary<int, string>();

            foreach (Intervals item in Enum.GetValues(typeof(Intervals)))
            {
                intervals.Add((int)item, item.ToString());
            }

            return Ok(intervals);
        }
    }
}
