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
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        Telefone = c.String(maxLength: 15, unicode: false),
                        UrlSite = c.String(maxLength: 512, unicode: false),
                        DataHoraCadastro = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 10, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VagaEmprego",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Subtitulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 512, unicode: false),
                        UrlImagem = c.String(maxLength: 512, unicode: false),
                        DataHoraCadastro = c.DateTime(nullable: false, precision: 0),
                        DataValidade = c.DateTime(nullable: false, precision: 0),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
            CreateTable(
                "dbo.VagaEstagio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Subtitulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 512, unicode: false),
                        UrlImagem = c.String(maxLength: 512, unicode: false),
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
            DropForeignKey("dbo.VagaEmprego", "Empresa_Id", "dbo.Empresa");
            DropIndex("dbo.VagaEstagio", new[] { "Empresa_Id" });
            DropIndex("dbo.VagaEmprego", new[] { "Empresa_Id" });
            DropTable("dbo.VagaEstagio");
            DropTable("dbo.VagaEmprego");
            DropTable("dbo.Tags");
            DropTable("dbo.Empresa");
        }
    }
}
