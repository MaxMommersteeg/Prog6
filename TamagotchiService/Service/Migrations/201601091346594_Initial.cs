namespace TamagotchiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.Tamagotchi",
                c => new
                    {
                        TamagotchiId = c.Int(nullable: false, identity: true),
                        Hunger = c.Int(nullable: false),
                        Sleep = c.Int(nullable: false),
                        Boredom = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Player_PlayerId = c.Int(),
                        TamagotchiState_TamagotchiStateId = c.Int(),
                    })
                .PrimaryKey(t => t.TamagotchiId)
                .ForeignKey("dbo.Player", t => t.Player_PlayerId)
                .ForeignKey("dbo.TamagotchiState", t => t.TamagotchiState_TamagotchiStateId)
                .Index(t => t.Player_PlayerId)
                .Index(t => t.TamagotchiState_TamagotchiStateId);
            
            CreateTable(
                "dbo.TamagotchiState",
                c => new
                    {
                        TamagotchiStateId = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TamagotchiStateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tamagotchi", "TamagotchiState_TamagotchiStateId", "dbo.TamagotchiState");
            DropForeignKey("dbo.Tamagotchi", "Player_PlayerId", "dbo.Player");
            DropIndex("dbo.Tamagotchi", new[] { "TamagotchiState_TamagotchiStateId" });
            DropIndex("dbo.Tamagotchi", new[] { "Player_PlayerId" });
            DropTable("dbo.TamagotchiState");
            DropTable("dbo.Tamagotchi");
            DropTable("dbo.Player");
        }
    }
}
