using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using BusinessLayer.Classes;
using BusinessLayer.Interfaces;
using RestSharp;
using DataAccessLayer.Classes;
using DataAccessLayer.Interfaces;

namespace A138204_Test
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IExtractPetsBusinessLogic, ExtractPetsBusinessLogic>();
            container.RegisterType<IGetPetsJson, GetPetsJson>();
            container.RegisterType<IRestClient, RestClient>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}