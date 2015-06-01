[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Campervibe.External.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Campervibe.External.UI.App_Start.NinjectWebCommon), "Stop")]

namespace Campervibe.External.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Campervibe.Data.Common;
    using Campervibe.Data.Core;
    using Campervibe.External.UI.ViewModelMappers.Account;
    using Campervibe.External.UI.ViewModelMappers.Booking;
    using Campervibe.External.UI.Security;
    using Campervibe.External.UI.ActionFilters;
    using System.Web.Mvc;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using Campervibe.External.UI.Logging;
    using Campervibe.Domain.InfrastructureContracts;
    using Campervibe.External.UI.ServiceProxies.Vehicle;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILog>().To<SqlLog>();
            kernel.Bind<IContextProvider>().To<GenericContextProvider>().InRequestScope();
            kernel.Bind<IRegisterViewModelMapper>().To<RegisterViewModelMapper>();
            kernel.Bind<IMakeViewModelMapper>().To<MakeViewModelMapper>();
            kernel.Bind<IGetPendingForVehicleViewModelMapper>().To<GetPendingForVehicleViewModelMapper>();
            kernel.Bind<IUserProvider>().To<UserProvider>();
            kernel.Bind<IIndexViewModelMapper>().To<IndexViewModelMapper>();
            kernel.Bind<IVehicleServiceProxy>().To<VehicleServiceProxy>();
            kernel.BindFilter<EntityFrameworkWriteContextFilter>(FilterScope.Action, 1000).WhenActionMethodHas<EntityFrameworkWriteContextAttribute>();
            kernel.BindFilter<EntityFrameworkReadContextFilter>(FilterScope.Action, 1000).WhenActionMethodHas<EntityFrameworkReadContextAttribute>();
            kernel.BindFilter<LogFilter>(FilterScope.Action, 1050).WhenActionMethodHas<LogAttribute>();
            
            new DataRegistry().RegisterServices(kernel);
        }        
    }
}
