
using Loja.Entidades;
using Loja.Infra;
using NHibernate;

namespace Loja.DAO
{
    public class PessoasDAO
    {
        ISession _session;
        public PessoasDAO(ISession session)
        {
            this._session = session;
        }
        public int Post(Pessoa pessoa)
        {
            ITransaction transaction = _session.BeginTransaction();
            _session.Save(pessoa);
            transaction.Commit();
            _session.Close();
            return 1;
        }

        public Pessoa GetById(int id)
        {
            return _session.Get<Pessoa>(id);
        }
    }
}
