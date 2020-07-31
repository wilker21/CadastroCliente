namespace CadastroCliente.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarSoftDelete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 500),
                        Documento = c.String(nullable: false, maxLength: 14),
                        DataCadastro = c.DateTime(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 12),
                        TipoPessoa = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
