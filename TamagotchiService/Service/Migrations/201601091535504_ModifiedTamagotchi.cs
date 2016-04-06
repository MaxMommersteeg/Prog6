namespace TamagotchiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTamagotchi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tamagotchi", "HungerValue", c => c.Int(nullable: false));
            AddColumn("dbo.Tamagotchi", "SleepValue", c => c.Int(nullable: false));
            AddColumn("dbo.Tamagotchi", "BoredomValue", c => c.Int(nullable: false));
            AddColumn("dbo.Tamagotchi", "HealthValue", c => c.Int(nullable: false));
            DropColumn("dbo.Tamagotchi", "Hunger");
            DropColumn("dbo.Tamagotchi", "Sleep");
            DropColumn("dbo.Tamagotchi", "Boredom");
            DropColumn("dbo.Tamagotchi", "Health");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tamagotchi", "Health", c => c.Int(nullable: false));
            AddColumn("dbo.Tamagotchi", "Boredom", c => c.Int(nullable: false));
            AddColumn("dbo.Tamagotchi", "Sleep", c => c.Int(nullable: false));
            AddColumn("dbo.Tamagotchi", "Hunger", c => c.Int(nullable: false));
            DropColumn("dbo.Tamagotchi", "HealthValue");
            DropColumn("dbo.Tamagotchi", "BoredomValue");
            DropColumn("dbo.Tamagotchi", "SleepValue");
            DropColumn("dbo.Tamagotchi", "HungerValue");
        }
    }
}
