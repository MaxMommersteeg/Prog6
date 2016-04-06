namespace TamagotchiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201601091717 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tamagotchi", "TamagotchiName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tamagotchi", "TamagotchiName");
        }
    }
}
