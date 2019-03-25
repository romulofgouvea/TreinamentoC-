using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Treinamento.Dominio;
using Treinamento.Persistencia.NHibernate.Maps;

namespace Treinamento.Repositorio
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        private ISessionFactory _sessionFactory;

        //NHIBERNATE
        public PessoaRepositorio()
        {
            Configuration config = new Configuration();
            config.Configure();
            config.AddAssembly( Assembly.GetExecutingAssembly() );
            
            _sessionFactory = config.BuildSessionFactory(); 
        }

        public List<Pessoa> GetAll()
        {
            using ( ISession session = _sessionFactory.OpenSession() )
            {
                return session.Query<Pessoa>().ToList();
            }
        }

        public int Post( Pessoa objeto )
        {
            using ( ISession session = _sessionFactory.OpenSession() )
            {
                using ( var transacao = session.BeginTransaction() )
                {
                    session.Save( objeto );
                    transacao.Commit();
                    return 1;
                }
            }
        }

        public Pessoa Get( int id )
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Get<Pessoa>( id );
            }
        }
    }
}
