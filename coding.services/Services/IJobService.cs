using coding.services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding.services.Services
{
    public interface IJobService
    {
       Task<List<JobDto>> GetJobs();
       Task<JobDto> GetJobById(long id);

        List<JobDto> GetJobs1();
    }
}
