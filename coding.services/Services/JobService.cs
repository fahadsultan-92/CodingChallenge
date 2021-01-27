using coding.services.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace coding.services.Services
{
    public class JobService : IJobService
    {
        readonly IJobAderService _jobAderService;
        readonly ICandidateService _candidateService;
        public JobService(IJobAderService jobAderService, ICandidateService candidateService)
        {
            _jobAderService = jobAderService;
            _candidateService = candidateService;
        }


        public virtual List<JobDto> GetJobs1() {
            List<JobDto> v = new List<JobDto>();

            v.Add(new JobDto { name = "JobA" });
            return v;
        }


        public async Task<List<JobDto>> GetJobs()
        {
            var jobs = await _jobAderService.GetJobs();
            jobs.ForEach(x =>
            {
                x.skillList = !string.IsNullOrEmpty(x.skills) ? x.skills.Split(',').Distinct().Select(y => new skill { name = y.Trim() }).ToList() : null;

            });

            foreach (var job in jobs)
            {
                var candidates = await _candidateService.GetMatchingCandidates(job.skillList);
                job.matchingCandidates = candidates.OrderByDescending(x => x.totalMatch).Take(1).ToList();
            }
            return jobs;
        }

        public async Task<JobDto> GetJobById(long id)
        {
            var jobs = await GetJobs();
            var candidates = await _candidateService.GetCandidates();
            var job = jobs.FirstOrDefault(x => x.jobId == id);
            if (job != null)
            {
                job.matchingCandidates = await _candidateService.GetMatchingCandidates(job.skillList);               
            }
            return job;
        }
      
    }
}
