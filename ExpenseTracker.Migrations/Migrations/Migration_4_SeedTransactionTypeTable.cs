using FluentMigrator;

namespace ExpenseTracker.Migrations.Migrations
{
    [Migration(4)]
    public class Migration_4_SeedTransactionTypeTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO dbo.TransactionType VALUES (1, 'Income');
                INSERT INTO dbo.TransactionType VALUES (2, 'Expense');
            ");
        }
    }
}