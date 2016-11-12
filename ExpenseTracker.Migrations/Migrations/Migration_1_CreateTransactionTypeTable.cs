using FluentMigrator;

namespace ExpenseTracker.Migrations.Migrations
{
    [Migration(1)]
    public class Migration_1_CreateTransactionTypeTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE dbo.TransactionType
                (
                    Id      INT PRIMARY KEY NOT NULL 
                    ,Name   VARCHAR(50) NOT NULL
                );
            ");
        }
    }
}
