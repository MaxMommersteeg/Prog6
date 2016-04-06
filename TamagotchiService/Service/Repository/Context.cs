using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TamagotchiService.Model;

namespace TamagotchiService.Repository {
    [DbConfigurationType(typeof(ContextConfiguration))]
    public class Context : DbContext {
        public Context() 
            : base("name=Azure"){
        }

        public virtual DbSet<Tamagotchi> Tamagotchies { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
    }
}