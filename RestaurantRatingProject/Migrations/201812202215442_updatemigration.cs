namespace RestaurantRatingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StarRatings", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.StarRatings", new[] { "Restaurant_RestaurantID" });
            AddColumn("dbo.Restaurants", "StarRatings", c => c.Int(nullable: false));
            DropColumn("dbo.StarRatings", "Restaurant_RestaurantID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StarRatings", "Restaurant_RestaurantID", c => c.Int());
            DropColumn("dbo.Restaurants", "StarRatings");
            CreateIndex("dbo.StarRatings", "Restaurant_RestaurantID");
            AddForeignKey("dbo.StarRatings", "Restaurant_RestaurantID", "dbo.Restaurants", "RestaurantID");
        }
    }
}
