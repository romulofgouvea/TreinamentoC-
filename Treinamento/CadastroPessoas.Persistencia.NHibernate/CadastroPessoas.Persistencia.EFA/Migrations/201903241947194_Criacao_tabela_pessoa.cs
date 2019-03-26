namespace CadastroPessoas.Persistencia.EFA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_tabela_pessoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoas");
        }
    }
}
