namespace DHL.Receipting.Core.Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
       // public override void Up() { }

        public override void Up()
        {
            CreateTable(
                "dbo.ACCESS_RIGHTS",
                c => new
                    {
                        TYPE_CODE = c.String(nullable: false, maxLength: 20, unicode: false),
                        PAGE_PATH = c.String(nullable: false, maxLength: 100, unicode: false),
                        ACCESS_RIGHTS = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.TYPE_CODE, t.PAGE_PATH, t.ACCESS_RIGHTS });
            
            CreateTable(
                "dbo.ACCESS_RIGHTS_MASTER",
                c => new
                    {
                        ACCESS_RIGHTS_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        ACCESS_RIGHTS_DESC = c.String(nullable: false, maxLength: 50, unicode: false),
                        ACC_ORDER = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ACCESS_RIGHTS_ID);
            
            CreateTable(
                "dbo.INVOICE_ACCESS_RIGHTS",
                c => new
                    {
                        MODULE_ID = c.String(nullable: false, maxLength: 20, unicode: false),
                        USER_TYPE = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.MODULE_ID, t.USER_TYPE });
            
            CreateTable(
                "dbo.LOGIN_BRANCH",
                c => new
                    {
                        USER_ID = c.Int(nullable: false),
                        BRANCH_CODE = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.USER_ID, t.BRANCH_CODE });
            
            CreateTable(
                "dbo.LOGIN",
                c => new
                    {
                        USER_ID = c.Int(nullable: false, identity: true),
                        USERNAME = c.String(nullable: false, maxLength: 100, unicode: false),
                        PASSWORD = c.String(nullable: false, maxLength: 100, unicode: false),
                        NAME = c.String(maxLength: 100, unicode: false),
                        USER_TYPE = c.String(maxLength: 50, unicode: false),
                        INACTIVE = c.Boolean(),
                        INACTIVE_USER = c.Int(),
                        INACTIVE_DATE = c.Decimal(precision: 18, scale: 0),
                        INACTIVE_DATETIME = c.DateTime(),
                        ADDED_USER = c.Int(),
                        ADDED_DATE = c.Decimal(precision: 18, scale: 0),
                        ADDED_DATETIME = c.DateTime(),
                    })
                .PrimaryKey(t => t.USER_ID);
            
            CreateTable(
                "dbo.MODULE_MASTER",
                c => new
                    {
                        MODULE_ID = c.Int(nullable: false, identity: true),
                        MODULE_DESC = c.String(nullable: false, maxLength: 1024, unicode: false),
                    })
                .PrimaryKey(t => t.MODULE_ID);
            
            CreateTable(
                "dbo.PAGES",
                c => new
                    {
                        PAGE_PATH = c.String(nullable: false, maxLength: 100, unicode: false),
                        PAGE_NAME = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.PAGE_PATH, t.PAGE_NAME });
            
            CreateTable(
                "dbo.USER_TYPE",
                c => new
                    {
                        TYPE_CODE = c.String(nullable: false, maxLength: 20, unicode: false),
                        TYPE_DESCRIPTION = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.TYPE_CODE, t.TYPE_DESCRIPTION });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.USER_TYPE");
            DropTable("dbo.PAGES");
            DropTable("dbo.MODULE_MASTER");
            DropTable("dbo.LOGIN");
            DropTable("dbo.LOGIN_BRANCH");
            DropTable("dbo.INVOICE_ACCESS_RIGHTS");
            DropTable("dbo.ACCESS_RIGHTS_MASTER");
            DropTable("dbo.ACCESS_RIGHTS");
        }
    }
}
