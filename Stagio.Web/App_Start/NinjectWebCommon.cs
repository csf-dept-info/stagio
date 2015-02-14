using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Stagio.DataLayer;
using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.Entities;
using Stagio.Web;
using Stagio.Web.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Stagio.Web
{
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
            //repositories
            kernel.Bind<IEntityRepository<Student>>().To<EfEntityRepository<Student>>().InRequestScope();
            kernel.Bind<IEntityRepository<Employee>>().To<EfEntityRepository<Employee>>().InRequestScope();
            kernel.Bind<IEntityRepository<ApplicationUser>>().To<EfEntityRepository<ApplicationUser>>().InRequestScope();
            kernel.Bind<IEntityRepository<Company>>().To<EfEntityRepository<Company>>().InRequestScope();
            kernel.Bind<IEntityRepository<Coordinator>>().To<EfEntityRepository<Coordinator>>().InRequestScope();
            kernel.Bind<IEntityRepository<UserRole>>().To<EfEntityRepository<UserRole>>().InRequestScope();
            kernel.Bind<IEntityRepository<InternshipOffer>>().To<EfEntityRepository<InternshipOffer>>().InRequestScope();
            kernel.Bind<IEntityRepository<InternshipApplication>>().To<EfEntityRepository<InternshipApplication>>().InRequestScope();
            kernel.Bind<IEntityRepository<InternshipPeriod>>().To<EfEntityRepository<InternshipPeriod>>().InRequestScope();
            kernel.Bind<IEntityRepository<Notification>>().To<EfEntityRepository<Notification>>().InRequestScope();
            kernel.Bind<IEntityRepository<InternshipAgreement>>().To<EfEntityRepository<InternshipAgreement>>().InRequestScope();

            //services
            kernel.Bind<IHttpContextService>().To<HttpContextService>().InRequestScope();
            kernel.Bind<IAccountService>().To<AccountService>().InRequestScope();
            kernel.Bind<IFileImportService>().To<FileImportService>().InRequestScope();
            kernel.Bind<IFileSaveService>().To<FileSaveService>().InRequestScope();
            kernel.Bind<IEmailService>().To<EmailService>().InRequestScope();
            kernel.Bind<IInternshipPeriodService>().To<InternshipPeriodService>().InRequestScope();
            kernel.Bind<INotificationService>().To<NotificationService>().InRequestScope();
            kernel.Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();

            //database
            kernel.Bind<IDatabaseHelper>().To<EfDatabaseHelper>().InRequestScope();
        }        
    }
}
