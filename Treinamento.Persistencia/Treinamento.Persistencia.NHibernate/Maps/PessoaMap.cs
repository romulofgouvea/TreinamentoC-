using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Treinamento.Dominio;

namespace Treinamento.Persistencia.NHibernate.Maps
{
    public class PessoaMap : ClassMapping<Pessoa>
    {
        public PessoaMap()
        {
            Table( "\"Pessoas\"" );// quando ja existe a tabela criada
            Schema( "dbo" );
            Id( pk => pk.Id, ( map ) => { map.Generator( Generators.Identity ); } );
            Property( p => p.Nome );
            Property( p => p.Idade );
            Property( p => p.Endereco );
        }
    }
}
