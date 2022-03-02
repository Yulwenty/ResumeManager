namespace ResumeManagerNarchitecture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 150),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Age = c.Int(nullable: false),
                        Qualification = c.String(nullable: false, maxLength: 50),
                        TotalExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.String(nullable: false, maxLength: 3),
                        ApplicantId = c.String(nullable: false, maxLength: 20),
                        CompanyName = c.String(maxLength: 30),
                        Designation = c.String(maxLength: 50),
                        YearsWorked = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExperienceId, t.ApplicantId })
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "ApplicantId", "dbo.Applicants");
            DropIndex("dbo.Experiences", new[] { "ApplicantId" });
            DropTable("dbo.Experiences");
            DropTable("dbo.Applicants");
        }
    }
}
