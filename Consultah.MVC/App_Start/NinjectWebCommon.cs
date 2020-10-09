[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Consultah.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Consultah.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Consultah.MVC.App_Start
{
    using System;
    using System.Web;
    using ConsultaH.Application;
    using ConsultaH.Application.Interface;
    using ConsultaH.Domain.Interfaces;
    using ConsultaH.Domain.Interfaces.Services;
    using ConsultaH.Domain.Services;
    using ConsultaH.Infra.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IPacienteAppService>().To<PacienteAppService>();
            kernel.Bind<IExameAppService>().To<ExameAppService>();
            kernel.Bind<ITipoExameAppService>().To<TipoExameAppService>();
            kernel.Bind<IConsultaAppService>().To<ConsultaAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IPacienteService>().To<PacienteService>();
            kernel.Bind<IExameService>().To<ExameService>();
            kernel.Bind<ITipoExameService>().To<TipoExameService>();
            kernel.Bind<IConsultaService>().To<ConsultaService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IPacienteRepository>().To<PacienteRepository>();
            kernel.Bind<IExameRepository>().To<ExameRepository>();
            kernel.Bind<ITipoExameRepository>().To<TipoExameRepository>();
            kernel.Bind<IConsultaRepository>().To<ConsultaRepository>();

        }
    }
}