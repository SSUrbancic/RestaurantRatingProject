namespace RestaurantRatingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addthestarratings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StarRatings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumberOfStars = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StarRatings");
        }
    }
}
