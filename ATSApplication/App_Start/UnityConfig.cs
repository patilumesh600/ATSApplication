using ATSApplication.Interfaces;
using ATSApplication.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ATSApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IAssetService, AssetService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}