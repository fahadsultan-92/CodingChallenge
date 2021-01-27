using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding.services.Contract
{
    public class CandidateDto
    {
        public long candidateId { get; set; }
        public string name { get; set; }
        public string skillTags { get; set; }
        public List<skill> skillTagList { get; set; }
    }

    public class skill {
        public string name { get; set; }
        public bool isMatch  {get;set;}
    }
}
