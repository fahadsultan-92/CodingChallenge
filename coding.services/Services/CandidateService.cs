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

    public class CandidateService : ICandidateService
    {
        readonly IJobAderService _jobAderService;
        public CandidateService(IJobAderService jobAderService)
        {
            _jobAderService = jobAderService;
        }

        private List<CandidateDto> _candidateList {get; set;}

        public async Task<List<CandidateDto>> GetCandidates()
        {
            if(_candidateList == null)
            {
                _candidateList = await _jobAderService.GetCandidates();
                _candidateList.ForEach(x =>
                {
                    x.skillTagList = !string.IsNullOrEmpty(x.skillTags) ? x.skillTags.Split(',').Distinct().Select(y => new skill { name = y.Trim() }).ToList() : null;
                });
            }            
            return _candidateList;
        }

        public async Task<List<MatchingCandidateDto>> GetMatchingCandidates(List<skill> skills)
        {
            var candidates = await GetCandidates();
            return candidates.Where(c => c.skillTagList.Any(x => skills.Any(y => y.name == x.name)))
                                   .Select(mc => new MatchingCandidateDto()
                                   {
                                       candidateId = mc.candidateId,
                                       name = mc.name,
                                       skillTags = mc.skillTags,
                                       skillTagList = mc.skillTagList,
                                       totalMatch = mc.skillTagList.Count(x => skills.Any(y => y.name == x.name))
                                   }).OrderByDescending(x => x.totalMatch).ToList();
        }       
    }
}
