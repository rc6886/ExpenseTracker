using FluentMigrator;

namespace ExpenseTracker.Migrations.Migrations
{
    [Migration(3)]
    public class Migration_3_CreateTransactionsTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE dbo.Transactions
                (
                    Id                  UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
                    ,VendorId           UNIQUEIDENTIFIER NOT NULL
                    ,TransactionTypeId  UNIQUEIDENTIFIER NOT NULL
                    ,Description        VARCHAR(100) NULL
                    ,Amount             DECIMAL NOT NULL
                    ,DateCreated        DATETIME NOT NULL
                    ,DateModified       DATETIME NULL
                    ,CONSTRAINT FK_Transaction_VendorId FOREIGN KEY (VendorId) REFERENCES dbo.Vendor(Id)
                    ,CONSTRAINT FK_Transaction_TransactionTypeId FOREIGN KEY (TransactionTypeId) REFERENCES dbo.TransactionType(Id)
                );
            ");
        }
    }
}
