using ParkMark.Infrastructure.API;
using ParkMark.Infrastructure.Log;
using ParkMark.Infrastructure.Repository;
using ParkMark.Logger;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ParkMark.Api.App_Start
{
    public class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify(VerificationOption.VerifyOnly);
            SuppressDiagnosticWarnin(container);
            container.Verify();

            //AutoMapperHelper.MapperInstance = container.GetInstance<AutoMapper.IMapper>();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            //Infrastructure.DI.DependencyContainer.SetContainer(container.GetInstance<IContainer>());
        }
        private static void SuppressDiagnosticWarnin(Container container)
        {
            Registration registration = container.GetRegistration(typeof(DbContext)).Registration;
            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "Reason of suppression");
        }

        private static void InitializeContainer(Container container)
        {
            InitializePackages(container);
            container.EnableHttpRequestMessageTracking(GlobalConfiguration.Configuration);
            container.Register<ILoggerFactory, LoggerFactory>(Lifestyle.Scoped);

            container.Register<Logger.ILogRequestContext>(() =>
            {
                var request = container.GetCurrentHttpRequestMessage();
                var rslt = new Logger.LogRequestContext(request);
                return rslt;
            }, Lifestyle.Scoped);


            container.Register<IUnitOfWork>(() => new EFUnitOfWorks(Model.API.ConfigValues.EntityFrameworkConntectionString), Lifestyle.Scoped);


            container.Register<IBaseApiControllerDependencies, BaseApiControllerDependencies>(Lifestyle.Scoped);

            container.RegisterConditional(typeof(ILogger),
                                        context =>
                                        {
                                            var impType = typeof(Logger.NLogProxy<>).MakeGenericType(context.Consumer.ImplementationType);
                                            return impType;
                                        },
                                        Lifestyle.Scoped, context => true);

            container.RegisterSingleton<AutoMapper.IMapper>(() =>
            {
                var cfg = new AutoMapper.Configuration.MapperConfigurationExpression();
                cfg.AddProfiles("ParkMark.Business");
                var mapperConfig = new AutoMapper.MapperConfiguration(cfg);
                var rslt = new AutoMapper.Mapper(mapperConfig);
                return rslt;
            });

        }
        private static void InitializePackages(Container container)
        {
            new Business.BusinessLogicDIPackage().RegisterServices(container);
        }
    }
}