[assembly: WebActivator.PostApplicationStartMethod(typeof(AirBnbUdC.GUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace AirBnbUdC.GUI.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using AirbnbUdC.Application.Contracts.Contracts.Parameters;
    using AirbnbUdc.Application.Implementation.Implementation.Parameters;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
    using AirbnbUdc.Repository.Implementation.Implementation.Parameters;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<ICityApplication, CityImplementationApplication>(Lifestyle.Scoped);
            container.Register<ICountryApplication, CountryImplementationApplication>(Lifestyle.Scoped);
            container.Register<ICityRepository, CityImplementationRepository>(Lifestyle.Scoped);
            container.Register<ICountryRepository, CountryImplementationRepository>(Lifestyle.Scoped);
            container.RegisterMvcControllers();

        }
    }
}