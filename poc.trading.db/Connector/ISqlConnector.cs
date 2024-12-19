using System.Data;

namespace poc.trading.db.Connector
{
    public interface ISqlConnector
    {
        Task<IEnumerable<T>> GetData<T>(string query, object? param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<int> Execute(string query, object? param = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
