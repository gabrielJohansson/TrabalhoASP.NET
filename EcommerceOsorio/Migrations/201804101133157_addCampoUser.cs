namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCampoUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID_Usuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Cep = c.String(),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Localidade = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.ID_Usuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
