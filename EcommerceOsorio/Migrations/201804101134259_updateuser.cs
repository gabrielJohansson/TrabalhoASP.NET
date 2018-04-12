namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Email", c => c.String());
            AddColumn("dbo.Usuarios", "ConfirmacaoSenha", c => c.String());
            DropColumn("dbo.Usuarios", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Login", c => c.String());
            DropColumn("dbo.Usuarios", "ConfirmacaoSenha");
            DropColumn("dbo.Usuarios", "Email");
        }
    }
}
