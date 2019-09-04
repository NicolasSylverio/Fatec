//using MySql.Data.Entity;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;

//namespace Fatec.Infra.DataBase.Context
//{
//    [DbConfigurationType(typeof(MySqlEFConfiguration))]
//    public class Contexto : DbContext
//    {
//        public Contexto() : base("ConnectionString")

//        {
//        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//        }
//    }
//}