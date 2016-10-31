using FluentMigrator;

namespace ExpenseTracker.Migrations.Migrations
{
    [Migration(2)]
    public class Migration_2_CreateVendorTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE dbo.Vendor
                (
                    Id              UNIQUEIDENTIFIER PRIMARY KEY 
                    ,Name           VARCHAR(50) NOT NULL
                    ,DateCreated    DATETIME NOT NULL
                    ,DateModified   DATETIME NULL
                );
            ");
        }
    }
}
