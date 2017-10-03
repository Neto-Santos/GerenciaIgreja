namespace GerenciaIgreja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InclusaoCampoAtivoTabelaMembro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Membroes", "Ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Membroes", "Ativo");
        }
    }
}
