namespace Fatec.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Telefone = c.String(unicode: false),
                        UrlSite = c.String(unicode: false),
                        DataHoraCadastro = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VagaEstagio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Subtitulo = c.String(unicode: false),
                        Descricao = c.String(unicode: false),
                        UrlImagem = c.String(unicode: false),
                        DataHoraCadastro = c.DateTime(nullable: false, precision: 0),
                        DataValidade = c.DateTime(nullable: false, precision: 0),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VagaEstagio", "Empresa_Id", "dbo.Empresa");
            DropIndex("dbo.VagaEstagio", new[] { "Empresa_Id" });
            DropTable("dbo.VagaEstagio");
            DropTable("dbo.Empresa");
        }
    }
}
