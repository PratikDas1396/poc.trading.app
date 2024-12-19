using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace poc.trading.db.Connector
{
    public class SqlConnector : ISqlConnector
    {
        private readonly string _connectionString;

        public SqlConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetData<T>(string query, object? param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(query, param, commandType: commandType);
            }
        }

        public async Task<int> Execute(string query, object? param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(query, param, commandType: commandType);
            }
        }

    }
}
