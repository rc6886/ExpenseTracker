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
                    Id              INT PRIMARY KEY NOT NULL IDENTITY(1, 1)
                    ,Name           VARCHAR(50) NOT NULL
                    ,DateCreated    DATETIME NOT NULL
                    ,DateModified   DATETIME NULL
                );
            ");
        }
    }
}
