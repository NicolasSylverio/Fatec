using Fatec.DataBase.Context;

namespace Fatec.DataBase.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<IntranetFatecContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IntranetFatecContext context)
        {

        }
    }
}