namespace Framework.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePrimKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Experience", "ApplicantId", "dbo.Applicant");
            DropIndex("dbo.Experience", new[] { "ApplicantId" });
            DropPrimaryKey("dbo.Applicant");
            DropPrimaryKey("dbo.Experience");
            DropColumn("dbo.Applicant", "Id");
            AddColumn("dbo.Applicant", "Id", c => c.String(nullable: false, maxLength: 20));

            DropColumn("dbo.Experience", "ExperienceId");
            AddColumn("dbo.Experience", "ExperienceId", c => c.String(nullable: false, maxLength: 3));

            DropColumn("dbo.Experience", "ApplicantId");
            AddColumn("dbo.Experience", "ApplicantId", c => c.String(nullable: false, maxLength: 20));

            AddPrimaryKey("dbo.Applicant", "Id");
            AddPrimaryKey("dbo.Experience", new[] { "ExperienceId", "ApplicantId" });
            CreateIndex("dbo.Experience", "ApplicantId");
            AddForeignKey("dbo.Experience", "ApplicantId", "dbo.Applicant", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experience", "ApplicantId", "dbo.Applicant");
            DropIndex("dbo.Experience", new[] { "ApplicantId" });
            DropPrimaryKey("dbo.Experience");
            DropPrimaryKey("dbo.Applicant");

            DropColumn("dbo.Experience", "ApplicantId");
            AddColumn("dbo.Experience", "ApplicantId", c => c.Int(nullable: false));

            DropColumn("dbo.Experience", "ExperienceId");
            AddColumn("dbo.Experience", "ExperienceId", c => c.Int(nullable: false, identity: true));

            DropColumn("dbo.Applicant", "Id");
            AddColumn("dbo.Applicant", "Id", c => c.Int(nullable: false, identity: true));

            AddPrimaryKey("dbo.Experience", "ExperienceId");
            AddPrimaryKey("dbo.Applicant", "Id");
            CreateIndex("dbo.Experience", "ApplicantId");
            AddForeignKey("dbo.Experience", "ApplicantId", "dbo.Applicant", "Id", cascadeDelete: true);
        }
    }
}
