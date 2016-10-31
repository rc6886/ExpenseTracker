using FluentMigrator;

namespace ExpenseTracker.Migrations.Migrations
{
    [Migration(4)]
    public class Migration_4_AlterTransactionsColumn : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                ALTER TABLE dbo.Transactions
                ALTER COLUMN Amount DECIMAL(18, 2) NOT NULL;
            ");
        }
    }
}