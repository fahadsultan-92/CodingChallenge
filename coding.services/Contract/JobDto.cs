using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding.services.Contract
{
    public class JobDto
    {
        public long jobId { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string skills { get; set; }
        public List<skill> skillList { get; set; }
        public List<MatchingCandidateDto> matchingCandidates { get; set; }
        
    }
}
