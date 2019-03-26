using CadastroPessoas.Dominio;
using CadastroPessoas.Persistencia.EFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoas.repositorio
{
    class PessoaRepositorio : IRepositorio<Pessoa>
    {
        public int Adicionar(Pessoa objeto)
        {
            CadastroPessoasDbContext context = new CadastroPessoasDbContext();
            context.Pessoas.Add(objeto);
            return context.SaveChanges();
        }

        public List<Pessoa> SelecionarTodos()
        {
            CadastroPessoasDbContext context = new CadastroPessoasDbContext();
            List<Pessoa> pessoas = context.Pessoas.OrderBy(o => o.Nome).ToList();
            context.Dispose();
            return pessoas;
        }
    }
}
