using CadastroPessoas.Dominio;
using System.Data.Entity;

namespace CadastroPessoas.Persistencia.EFA
{
    public class CadastroPessoasDbContext : DbContext
    {

        //private readonly string schema;

        public CadastroPessoasDbContext() : base("CadastroPessoas")
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }

        //protected override void OnModelCreating(DbModelBuilder builder)
        //{
        //    builder.HasDefaultSchema(this.schema);
        //    base.OnModelCreating(builder);
        //}
    }
}
