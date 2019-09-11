namespace Fatec.DataBase.Migrations
{
    using Fatec.Infra.DataBase.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<IntranetFatecContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IntranetFatecContext context)
        {
        }
    }
}
