using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using MVCIocExample.Repository;

namespace MVCIocExample
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // Register IOC PersonRepository
            container.RegisterType<IPersonRepository, PersonRepository>(
            // More IOC....
            new HierarchicalLifetimeManager()
            );            

            return container;
        }
    }
}