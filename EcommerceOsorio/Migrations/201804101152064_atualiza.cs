namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualiza : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "ConfirmacaoSenha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "ConfirmacaoSenha", c => c.String());
        }
    }
}
