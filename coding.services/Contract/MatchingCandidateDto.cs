using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding.services.Contract
{
    public class MatchingCandidateDto : CandidateDto
    {
        public int totalMatch { get; set; }
    }
}
