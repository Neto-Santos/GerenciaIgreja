namespace GerenciaIgreja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incluindo_Required_Nome_FuncaoMinisterial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FuncaoMinisterials", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FuncaoMinisterials", "Nome", c => c.String());
        }
    }
}
