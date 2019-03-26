using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra
{
    public class NhibernateHelper
    {
        private static ISessionFactory _sessionFactory = LoadSessionFactory();

        public static Configuration LoadConfiguration()
        {
            Configuration config = new Configuration().Configure();
            return config.AddAssembly(Assembly.GetExecutingAssembly());
        }

        public static void LoadSchema()
        {
            Configuration config = LoadConfiguration();
            new SchemaExport(config).Create(true,true);
        }

        private static ISessionFactory LoadSessionFactory()
        {
            return LoadConfiguration().BuildSessionFactory();
        }

        public static ISession CreateSession()
        {
            return _sessionFactory.OpenSession();
        }

    }
}
