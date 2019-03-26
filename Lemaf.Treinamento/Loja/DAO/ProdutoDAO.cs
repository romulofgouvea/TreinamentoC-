using Loja.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace Loja.DAO
{
    public class ProdutoDAO
    {
        static ISession _session;
        public ProdutoDAO( ISession session )
        {
            _session = session;
        }

        public int Post( Produto objeto, bool close = false )
        {
            ITransaction transaction = _session.BeginTransaction();
            _session.Save( objeto );
            transaction.Commit();
            if ( close )
                _session.Close();
            return 1;
        }

        public Produto GetById( int id )
        {
            return _session.Get<Produto>( id );
        }

        public static IList<Produto> BuscaNomePrecoCategoria( string nome, decimal precoMinimo, string categoria )
        {
            ICriteria criteria = _session.CreateCriteria( typeof( Produto ) );

            if ( !string.IsNullOrEmpty( nome ) )
            {
                criteria.Add( Restrictions.Eq( "Nome", nome ) );
            }

            if ( precoMinimo > 0 )
            {
                criteria.Add( Restrictions.Ge( "Preco", precoMinimo ) );
            }

            if ( !string.IsNullOrEmpty( categoria ) )
            {
                ICriteria criteriaCategoria = criteria.CreateCriteria( "Categoria" );
                criteriaCategoria.Add( Restrictions.Eq( "Nome", categoria ) );
            }


            return criteria.List<Produto>();
        }
    }
}
