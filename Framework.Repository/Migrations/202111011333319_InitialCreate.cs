namespace Framework.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Age = c.Int(nullable: false),
                        Qualification = c.String(nullable: false, maxLength: 50),
                        TotalExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Designation = c.String(),
                        YearsWorked = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.Applicant", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experience", "ApplicantId", "dbo.Applicant");
            DropIndex("dbo.Experience", new[] { "ApplicantId" });
            DropTable("dbo.Experience");
            DropTable("dbo.Applicant");
        }
    }
}
