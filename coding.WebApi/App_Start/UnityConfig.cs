using coding.services.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace coding.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            container.RegisterType<IJobService, JobService>();
            container.RegisterType<ICandidateService, CandidateService>();
            container.RegisterType<IJobAderService, JobAderService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}