namespace TamagotchiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201601100154 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tamagotchi", "LastAccess", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tamagotchi", "LastAccess");
        }
    }
}
