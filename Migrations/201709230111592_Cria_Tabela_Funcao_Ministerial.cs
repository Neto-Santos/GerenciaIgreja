namespace GerenciaIgreja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cria_Tabela_Funcao_Ministerial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FuncaoMinisterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FuncaoMinisterials");
        }
    }
}
