[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Campervibe.Internal.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Campervibe.Internal.UI.App_Start.NinjectWebCommon), "Stop")]

namespace Campervibe.Internal.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Campervibe.Data.Common;
    using Campervibe.Internal.UI.ViewModelMappers.Booking;
    using Campervibe.Internal.UI.Security;
    using Campervibe.Data.Core;
    using Campervibe.Internal.UI.ViewModelMappers.Invoice;
    using Campervibe.Internal.UI.ActionFilters;
    using System.Web.Mvc;
    using Campervibe.Domain.InfrastructureContracts;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using Campervibe.Internal.UI.Logging;

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
            kernel.Bind<IEmailer>().To<StubEmailer>();
            kernel.Bind<IContextProvider>().To<GenericContextProvider>().InRequestScope();
            kernel.Bind<ICollectViewModelMapper>().To<CollectViewModelMapper>();
            kernel.Bind<IReturnViewModelMapper>().To<ReturnViewModelMapper>();
            kernel.Bind<IGetSummaryViewModelMapper>().To<GetSummaryViewModelMapper>();
            kernel.Bind<IGenerateViewModelMapper>().To<GenerateViewModelMapper>();
            kernel.Bind<IUserProvider>().To<UserProvider>();
            kernel.BindFilter<EntityFrameworkWriteContextFilter>(FilterScope.Action, 1000).WhenActionMethodHas<EntityFrameworkWriteContextAttribute>();
            kernel.BindFilter<EntityFrameworkReadContextFilter>(FilterScope.Action, 1000).WhenActionMethodHas<EntityFrameworkReadContextAttribute>();
            kernel.BindFilter<LogFilter>(FilterScope.Action, 1050).WhenActionMethodHas<LogAttribute>();
            new DataRegistry().RegisterServices(kernel);
        }        
    }
}
