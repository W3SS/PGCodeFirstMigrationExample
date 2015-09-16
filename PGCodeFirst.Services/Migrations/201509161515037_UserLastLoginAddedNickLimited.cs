namespace PGCodeFirst.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLastLoginAddedNickLimited : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.User", "LastLogin", c => c.DateTime(nullable: false));
            AlterColumn("public.User", "Nick", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("public.User", "Nick", c => c.String());
            DropColumn("public.User", "LastLogin");
        }
    }
}
