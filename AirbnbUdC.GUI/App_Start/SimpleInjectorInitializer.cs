[assembly: WebActivator.PostApplicationStartMethod(typeof(AirbnbUdC.GUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace AirbnbUdC.GUI.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<ICityRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}