namespace Fatec.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VagaEstagio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Subtitulo = c.String(unicode: false),
                        Descricao = c.String(unicode: false),
                        Empresa = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Telefone = c.String(unicode: false),
                        URLImagem = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VagaEstagio");
        }
    }
}
