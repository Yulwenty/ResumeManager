namespace Framework.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu_List",
                c => new
                    {
                        M_CODE = c.Int(nullable: false, identity: true),
                        M_PARENT_CODE = c.Int(),
                        M_NAME = c.String(maxLength: 50),
                        CONTROLLER_NAME = c.String(maxLength: 50),
                        ACTION_NAME = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.M_CODE);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menu_List");
        }
    }
}
