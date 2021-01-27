using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coding.services.Contract;
using coding.services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace coding.UnitTest
{
    [TestClass]
    public class MatchingCandidateTest
    {

        Mock<IJobAderService>  mockJobAder = new Mock<IJobAderService>();
        Mock<ICandidateService> mockCanSer = new Mock<ICandidateService>();
        List<CandidateDto> mockCandidates = new List<CandidateDto>();

        [TestInitialize]
        public void Setup()
        {
            mockCandidates.Add(new CandidateDto() { candidateId = 1, name = "A", skillTags= "mobile,javas,wift,iOS,xcode"  });
            mockCandidates.Add(new CandidateDto() { candidateId = 2, name = "B", skillTags = "fastlane,detail,data-entry,cooking,service"});
            mockCandidates.Add(new CandidateDto() { candidateId = 3, name = "C", skillTags = "aws,kotlin,data-entry,mobile,service" });
            mockCandidates.Add(new CandidateDto() { candidateId = 4, name = "D", skillTags = "iOS,swift,data-entry,xcode,service" });
            mockJobAder.Setup(x => x.GetCandidates()).Returns(Task.FromResult(mockCandidates));
        }


        [TestMethod]
        public async Task BestMatchingCandidate()
        {
            var job = new JobDto() { name = "Mobile Developer", skillList = new List<skill>() { new skill { name = "mobile" }, new skill { name = "java" }, new skill { name = "swift" }, new skill { name = "iOS" }, new skill { name = "xcode" } } };
            var _candidateService = new CandidateService(mockJobAder.Object);
            var res = await _candidateService.GetMatchingCandidates(job.skillList);
            var topCandidate = res.FirstOrDefault();
            Assert.IsTrue(topCandidate.name == "A");
        }

        [TestMethod]
        public async Task LeastMatchingCandidate()
        {
            var job = new JobDto() { name = "Mobile Developer", skillList = new List<skill>() { new skill { name = "mobile" }, new skill { name = "java" }, new skill { name = "swift" }, new skill { name = "iOS" }, new skill { name = "xcode" } } };
            var _candidateService = new CandidateService(mockJobAder.Object);
            var res = await _candidateService.GetMatchingCandidates(job.skillList);
            var topCandidate = res.LastOrDefault();
            Assert.IsTrue(topCandidate.name == "C");
        }

        [TestMethod]
        public async Task NoMatchingCandidate()
        {
            var job = new JobDto() { name = "Mobile Developer", skillList = new List<skill>() { new skill { name = "1mobile" }, new skill { name = "1java" }, new skill { name = "1swift" }, new skill { name = "1iOS" }, new skill { name = "1xcode" } } };
            var _candidateService = new CandidateService(mockJobAder.Object);
            var res = await _candidateService.GetMatchingCandidates(job.skillList);
            Assert.IsTrue(res.Count() == 0);
        }


        [TestMethod]
        public async Task TotalMatchingCandidate()
        {
            var job = new JobDto() { name = "Mobile Developer", skillList = new List<skill>() { new skill { name = "mobile" }, new skill { name = "java" }, new skill { name = "swift" }, new skill { name = "iOS" }, new skill { name = "xcode" } } };
            var _candidateService = new CandidateService(mockJobAder.Object);
            var res = await _candidateService.GetMatchingCandidates(job.skillList);
            Assert.IsTrue(res.Count() == 3);
        }
       
    }
}
