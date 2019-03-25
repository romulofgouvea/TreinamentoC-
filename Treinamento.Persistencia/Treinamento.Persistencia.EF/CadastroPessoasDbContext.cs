using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.Dominio;

namespace Treinamento.Persistencia.EF
{
    public class CadastroPessoasDbContext: DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public CadastroPessoasDbContext(): base( "CadastroPessoas" )
        {

        }


    }
}
