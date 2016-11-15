namespace HomeCrud.Test.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeCrud.Test.Specs.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HomeCrud.Test.Specs.DataBaseContext";
        }

        protected override void Seed(HomeCrud.Test.Specs.DataBaseContext context)
        {
        }
    }
}
