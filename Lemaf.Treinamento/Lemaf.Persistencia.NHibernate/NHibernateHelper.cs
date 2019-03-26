
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Lemaf.Persistencia.NHibernate
{
    public class NHibernateHelper
    {
        static Configuration _configuration = new Configuration();

        public static Configuration LoadConfiguration()
        {
            _configuration.Configure();
            _configuration.AddAssembly(Assembly.GetExecutingAssembly());
            return _configuration;
        }

        //gerar as tabelas no banco de dados
        public static void LoadSchema()
        {
            Configuration config = LoadConfiguration();
            try
            {
                new SchemaValidator(config).Validate();
            }
            catch
            {
                new SchemaExport(config).Create(false, true);
            }
        }
    }
}
