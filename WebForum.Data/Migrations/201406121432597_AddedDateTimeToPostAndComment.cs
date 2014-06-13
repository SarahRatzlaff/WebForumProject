namespace WebForum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTimeToPostAndComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Posted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "Posted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Posted");
            DropColumn("dbo.Posts", "Posted");
        }
    }
}
