namespace GerenciaIgreja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaMembro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Membroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Membroes");
        }
    }
}
