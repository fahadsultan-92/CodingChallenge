using coding.services.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace coding.services.Services
{
    public class JobAderService : IJobAderService
    {
        public async Task<List<JobDto>> GetJobs()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var url = ConfigurationManager.AppSettings["serviceName"];
                var response= await httpClient.GetAsync($"{url}/jobs");
                var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<JobDto>>(str);
            }
        }

        public async Task<List<CandidateDto>> GetCandidates()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var url = ConfigurationManager.AppSettings["serviceName"];
                var response = await httpClient.GetAsync($"{url}/candidates");
                var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CandidateDto>>(str);
            }
        }
    }
}
