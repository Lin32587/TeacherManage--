namespace StudentsManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CID = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        CName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.Score",
                c => new
                    {
                        SID = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        UserID = c.String(nullable: false, maxLength: 12, fixedLength: true),
                        CID = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        Grade = c.Int(nullable: false),
                        Place = c.String(),
                        TestTime = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.SID)
                .ForeignKey("dbo.User", t => t.UserID)
                .ForeignKey("dbo.Course", t => t.CID)
                .Index(t => t.UserID)
                .Index(t => t.CID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 12, fixedLength: true),
                        UserName = c.String(nullable: false),
                        SClass = c.String(),
                        Pwd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Score", "CID", "dbo.Course");
            DropForeignKey("dbo.Score", "UserID", "dbo.User");
            DropIndex("dbo.Score", new[] { "CID" });
            DropIndex("dbo.Score", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Score");
            DropTable("dbo.Course");
        }
    }
}
