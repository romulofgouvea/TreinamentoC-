using Lemaf.Persistencia.NHibernate;
using Lemaf.Persistencia.NHibernate.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemaf.Repositorio
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        public PessoaRepositorio()
        {
            NHibernateHelper.LoadSchema();
        }

        public List<Pessoa> GelAll()
        {
            throw new NotImplementedException();
        }
    }
}
