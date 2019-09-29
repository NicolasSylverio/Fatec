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
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 15, unicode: false),
                        UrlSite = c.String(maxLength: 15, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.VagaEmprego",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Subtitulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 512, unicode: false),
                        UrlImagem = c.String(nullable: false, maxLength: 512, unicode: false),
                        DataHoraCadastro = c.DateTime(nullable: false, precision: 0),
                        DataValidade = c.DateTime(nullable: false, precision: 0),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.Titulo, unique: true, name: "IX_Nome")
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 12, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.VagaEstagio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Subtitulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 512, unicode: false),
                        UrlImagem = c.String(nullable: false, maxLength: 512, unicode: false),
                        DataHoraCadastro = c.DateTime(nullable: false, precision: 0),
                        DataValidade = c.DateTime(nullable: false, precision: 0),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.Titulo, unique: true, name: "IX_Nome")
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.VagaEmpregoTags",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        VagaEmpregoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.VagaEmpregoId })
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.VagaEmprego", t => t.VagaEmpregoId)
                .Index(t => t.TagId)
                .Index(t => t.VagaEmpregoId);
            
            CreateTable(
                "dbo.VagaEstagioTags",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        VagaEstagioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.VagaEstagioId })
                .ForeignKey("dbo.Tags", t => t.TagId)
                .ForeignKey("dbo.VagaEstagio", t => t.VagaEstagioId)
                .Index(t => t.TagId)
                .Index(t => t.VagaEstagioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VagaEstagio", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.VagaEmprego", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.VagaEstagioTags", "VagaEstagioId", "dbo.VagaEstagio");
            DropForeignKey("dbo.VagaEstagioTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.VagaEmpregoTags", "VagaEmpregoId", "dbo.VagaEmprego");
            DropForeignKey("dbo.VagaEmpregoTags", "TagId", "dbo.Tags");
            DropIndex("dbo.VagaEstagioTags", new[] { "VagaEstagioId" });
            DropIndex("dbo.VagaEstagioTags", new[] { "TagId" });
            DropIndex("dbo.VagaEmpregoTags", new[] { "VagaEmpregoId" });
            DropIndex("dbo.VagaEmpregoTags", new[] { "TagId" });
            DropIndex("dbo.VagaEstagio", new[] { "EmpresaId" });
            DropIndex("dbo.VagaEstagio", "IX_Nome");
            DropIndex("dbo.Tags", new[] { "Nome" });
            DropIndex("dbo.VagaEmprego", new[] { "EmpresaId" });
            DropIndex("dbo.VagaEmprego", "IX_Nome");
            DropIndex("dbo.Empresa", new[] { "Nome" });
            DropTable("dbo.VagaEstagioTags");
            DropTable("dbo.VagaEmpregoTags");
            DropTable("dbo.VagaEstagio");
            DropTable("dbo.Tags");
            DropTable("dbo.VagaEmprego");
            DropTable("dbo.Empresa");
        }
    }
}
