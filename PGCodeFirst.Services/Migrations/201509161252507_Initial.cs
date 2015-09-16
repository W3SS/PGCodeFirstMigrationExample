namespace PGCodeFirst.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Interest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nick = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "public.UserInterests",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.InterestId })
                .ForeignKey("public.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("public.Interest", t => t.InterestId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.InterestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.UserInterests", "InterestId", "public.Interest");
            DropForeignKey("public.UserInterests", "UserId", "public.User");
            DropForeignKey("public.User", "CityId", "public.City");
            DropIndex("public.UserInterests", new[] { "InterestId" });
            DropIndex("public.UserInterests", new[] { "UserId" });
            DropIndex("public.User", new[] { "CityId" });
            DropTable("public.UserInterests");
            DropTable("public.User");
            DropTable("public.Interest");
            DropTable("public.City");
        }
    }
}
