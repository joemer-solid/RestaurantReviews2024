using RestaurantReviews2024.Repository;
using System.Data.SQLite;

namespace RestaurantReviewService.Commands.Builder
{
	public abstract class SqlLiteCommandBuilderBase : SqliteDbConnection, ISqlLiteCommandBuilder<SQLiteCommand>
    {
        public SqlLiteCommandBuilderBase(SqliteDbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        protected SqliteDbConnection DbConnection { get; private set; }

        public abstract SQLiteCommand Build();
    }
}
