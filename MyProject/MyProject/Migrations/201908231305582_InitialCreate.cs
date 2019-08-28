namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Description = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        User_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Name)
                .Index(t => t.User_Name);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Adress = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyTasks", "User_Name", "dbo.Users");
            DropIndex("dbo.MyTasks", new[] { "User_Name" });
            DropTable("dbo.Users");
            DropTable("dbo.MyTasks");
        }
    }
}
