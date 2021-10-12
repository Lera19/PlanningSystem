namespace PlanningSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusesForRejection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "StatusesForRejection", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "StatusesForRejection");
        }
    }
}
