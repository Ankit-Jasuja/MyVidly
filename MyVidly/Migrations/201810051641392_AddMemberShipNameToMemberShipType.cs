namespace MyVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberShipNameToMemberShipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MemberShipName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MemberShipName");
        }
    }
}
