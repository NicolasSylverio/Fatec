namespace Fatec.DataBase.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
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
                        UrlSite = c.String(maxLength: 200, unicode: false),
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
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
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
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataValidade = c.DateTime(nullable: false, precision: 0),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.Titulo, unique: true, name: "IX_Nome")
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
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
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VagaEstagio", new[] { "EmpresaId" });
            DropIndex("dbo.VagaEstagio", "IX_Nome");
            DropIndex("dbo.Tags", new[] { "Nome" });
            DropIndex("dbo.VagaEmprego", new[] { "EmpresaId" });
            DropIndex("dbo.VagaEmprego", "IX_Nome");
            DropIndex("dbo.Empresa", new[] { "Nome" });
            DropTable("dbo.VagaEstagioTags");
            DropTable("dbo.VagaEmpregoTags");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.VagaEstagio");
            DropTable("dbo.Tags");
            DropTable("dbo.VagaEmprego");
            DropTable("dbo.Empresa");
        }
    }
}
