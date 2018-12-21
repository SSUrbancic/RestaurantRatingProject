namespace RestaurantRatingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelBack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StarRatings", "Restaurant_RestaurantID", c => c.Int());
            CreateIndex("dbo.StarRatings", "Restaurant_RestaurantID");
            AddForeignKey("dbo.StarRatings", "Restaurant_RestaurantID", "dbo.Restaurants", "RestaurantID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StarRatings", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.StarRatings", new[] { "Restaurant_RestaurantID" });
            DropColumn("dbo.StarRatings", "Restaurant_RestaurantID");
        }
    }
}
