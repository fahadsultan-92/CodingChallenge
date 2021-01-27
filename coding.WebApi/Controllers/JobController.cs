using coding.services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace coding.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class JobController : ApiController
    {
        IJobService _jobService;
        ICandidateService _candidateService;
        public JobController(IJobService jobService, ICandidateService candidateService)
        {
            _jobService = jobService;
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _jobService.GetJobs();
            return Json(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(long id)
        {
            var result = await _jobService.GetJobById(id);
            return Json(result);
        }

    }
}
