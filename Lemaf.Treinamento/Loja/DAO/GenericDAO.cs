using Loja.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace Loja.DAO
{
    public abstract class GenericDAO<T>
    {
        ISession _session;
        public GenericDAO( ISession session )
        {
            this._session = session;
        }

        public int Post( T objeto, bool close = false )
        {
            ITransaction transaction = _session.BeginTransaction();
            _session.Save( objeto );
            transaction.Commit();
            if ( close )
                _session.Close();
            return 1;
        }

        public T GetById( int id )
        {
            return _session.Get<T>( id );
        }

        public IList<T> BuscaNomePrecoCategoria( string nome, decimal precoMinimo, string categoria )
        {
            ICriteria criteria = _session.CreateCriteria( typeof( T ) );

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
                criteria.Add( Restrictions.Eq( "Preco", precoMinimo ) );
            }


            return criteria.List<T>();
        }
    }
}
