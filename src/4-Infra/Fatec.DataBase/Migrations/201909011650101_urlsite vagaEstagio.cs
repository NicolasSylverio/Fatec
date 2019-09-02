namespace Fatec.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urlsitevagaEstagio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VagaEstagio", "URLSite", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VagaEstagio", "URLSite");
        }
    }
}
