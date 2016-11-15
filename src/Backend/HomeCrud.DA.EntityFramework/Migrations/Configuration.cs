namespace HomeCrud.DA.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HomeCrud.Test.Specs.DataBaseContext";
        }

        protected override void Seed(DataBaseContext context)
        {
        }
    }
}
