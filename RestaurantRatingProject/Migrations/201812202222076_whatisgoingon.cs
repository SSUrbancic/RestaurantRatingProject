namespace RestaurantRatingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatisgoingon : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "StarRatings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "StarRatings", c => c.Int(nullable: false));
        }
    }
}
