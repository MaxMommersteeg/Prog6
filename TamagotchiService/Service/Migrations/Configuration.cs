namespace TamagotchiService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;
    using System.Collections.Generic;
    using Repository;

    internal sealed class Configuration : DbMigrationsConfiguration<TamagotchiService.Repository.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TamagotchiService.Repository.Context context)
        {
        }
    }
}
