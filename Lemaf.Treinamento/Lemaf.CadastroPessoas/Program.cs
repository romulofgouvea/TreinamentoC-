using Lemaf.Persistencia.NHibernate.Maps;
using Lemaf.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemaf.CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositorio<Pessoa> repositorio = new PessoaRepositorio();

            Console.ReadKey();
        }
    }
}
