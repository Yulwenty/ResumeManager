namespace Framework.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCompanyNameLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Experience", "CompanyName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Experience", "Designation", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Experience", "Designation", c => c.String());
            AlterColumn("dbo.Experience", "CompanyName", c => c.String());
        }
    }
}
