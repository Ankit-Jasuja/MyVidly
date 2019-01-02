namespace MyVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7553495d-13b0-4aeb-a2ce-8bb40b31af74', N'admin@vidly.com', 0, N'AJvF9LxecMvs/fpia1lE1T1kCXdPbcCOtlTf/Xlnrj/z12U4oDMQnGNE1TcBHV3vsA==', N'970276b9-29c3-4c18-a035-84f58f2a1f03', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c5056f77-24eb-4199-9493-91519d0887fa', N'guest@vidly.com', 0, N'AFGC6sJy1LHn6Nb9BaumZULXj0a7Djjxn3asWf007h8fdXarw3ycv/Jf1ZvZ/mKQpA==', N'60b061ba-0a3c-4e76-9f8f-375d0b738173', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bdc5a8c8-640e-4595-9437-7920c542a429', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7553495d-13b0-4aeb-a2ce-8bb40b31af74', N'bdc5a8c8-640e-4595-9437-7920c542a429')
");
        }
        
        public override void Down()
        {
        }
    }
}
