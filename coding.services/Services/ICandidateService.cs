using coding.services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding.services.Services
{
    public interface ICandidateService
    {
        Task<List<CandidateDto>> GetCandidates();
        Task<List<MatchingCandidateDto>> GetMatchingCandidates(List<skill> skills);
    }
}
