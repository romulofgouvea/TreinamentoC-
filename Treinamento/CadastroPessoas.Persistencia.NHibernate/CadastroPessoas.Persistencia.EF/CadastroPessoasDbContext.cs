using CadastroPessoas.Dominio;
using System.Data.Entity;

namespace CadastroPessoas.Persistencia.EF
{
    public class CadastroPessoasDbContext: DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
