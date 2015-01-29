using System.Data.Entity;

namespace Stagio.DataLayer.EntityFramework
{
    public class EfDatabaseConfiguration : DbConfiguration
    {
        public EfDatabaseConfiguration()
        {
            SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}

// La chaine de connexion est définie dans web.config de Miam.Web
//
// Pour l'explication concernant l'héritage avec DbConfiguration voir:
// http://msdn.microsoft.com/en-us/library/system.data.entity.dbconfiguration(v=vs.113).aspx 
// http://msdn.microsoft.com/en-US/data/jj680699
//
// Configuration for an Entity Framework application can be specified in a config file (app.config/web.config) or through code.
// The latter is known as code-based configuration. 
// Configuration in a config file is described in a separate article. 
// The config file takes precedence over code-based configuration. 
// In other words, if a configuration option is set in both code and in the config file, 
// then the setting in the config file is used.