namespace Framework.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppAutoNumberLast",
                c => new
                    {
                        SRAutoNumber = c.String(nullable: false, maxLength: 20),
                        EffectiveDate = c.DateTime(nullable: false),
                        YearNo = c.Int(nullable: false),
                        LastNumber = c.Int(),
                        LastCompleteNumber = c.String(maxLength: 20),
                        LastUpdateDateTime = c.DateTime(),
                        LastUpdateByUserId = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => new { t.SRAutoNumber, t.EffectiveDate, t.YearNo });
            
            CreateTable(
                "dbo.AppAutoNumber",
                c => new
                    {
                        SRAutoNumber = c.String(nullable: false, maxLength: 20),
                        EffectiveDate = c.DateTime(nullable: false),
                        Prefik = c.String(maxLength: 5),
                        SeparatorAfterPrefik = c.String(maxLength: 1),
                        YearDigit = c.Int(),
                        SeparatorAfterYear = c.String(maxLength: 20),
                        NumberLength = c.Int(),
                        LastUpdateDateTime = c.DateTime(),
                        LastUpdateByUser = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => new { t.SRAutoNumber, t.EffectiveDate });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppAutoNumber");
            DropTable("dbo.AppAutoNumberLast");
        }
    }
}
