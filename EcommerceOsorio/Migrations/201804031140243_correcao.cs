namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        Cliente = c.String(),
                        Data = c.DateTime(nullable: false),
                        Endereco = c.String(),
                        ItemVendaCarrinhoId = c.String(),
                    })
                .PrimaryKey(t => t.VendaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendas");
        }
    }
}
