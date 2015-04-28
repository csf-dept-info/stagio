using System.Configuration;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Stagio.DataLayer;
using Stagio.Web.Mappers;

namespace Stagio.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Todo: L'environnment dev devrait aussi être en HTTPS
            if (ConfigurationManager.AppSettings["environment"] == "prod")
            {
                GlobalFilters.Filters.Add(new RequireHttpsAttribute());    
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // C'est dans NinjectWebCommon.cs que la dépendance (sur EFDatabaseHelper) est gérée
            var dbInitializer = DependencyResolver.Current.GetService<IDatabaseHelper>();
            dbInitializer.DropCreateDatabaseIfModelChanges();

            AutoMapperConfiguration.Configure();

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
