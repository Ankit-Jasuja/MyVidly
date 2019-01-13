namespace MyVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droprentaltable : DbMigration
    {
        public override void Up()
        {
            DropTable("Rentals");
        }
        
        public override void Down()
        {
        }
    }
}
