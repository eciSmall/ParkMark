[assembly: WebActivator.PostApplicationStartMethod(typeof(ParkMark.UI.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ParkMark.UI.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using ParkMark.Infrastructure.Log;
    using ParkMark.Logger;
    using System.Web;
    using ParkMark.UI.Web.General.BaseController;

    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            //Infrastructure.DI.DependencyContainer.SetContainer(container.GetInstance<IContainer>());
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IBaseControllerDependencies, BaseControllerDependencies>(Lifestyle.Scoped);
            container.RegisterConditional(typeof(ILogger),
                                   context => typeof(NLogProxy<>).MakeGenericType(context.Consumer.ImplementationType),
                                   Lifestyle.Scoped, context => true);
            container.Register<ILoggerFactory, LoggerFactory>(Lifestyle.Scoped);

            container.Register<Logger.ILogRequestContext>(() =>
            {
                var rslt = new General.WebUILogRequestContext(new HttpContextWrapper(System.Web.HttpContext.Current));
                return rslt;
            }, Lifestyle.Scoped);

            container.RegisterSingleton<AutoMapper.IMapper>(() =>
            {
                var cfg = new AutoMapper.Configuration.MapperConfigurationExpression();
                cfg.AddProfiles("ParkMark.UI.Web");
                var mapperConfig = new AutoMapper.MapperConfiguration(cfg);
                var rslt = new AutoMapper.Mapper(mapperConfig);
                return rslt;
            });

        }
    }
}