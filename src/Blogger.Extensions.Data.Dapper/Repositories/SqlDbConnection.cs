using System.Data;
using System.Data.SqlClient;

namespace Blogger.Extensions.Data.Dapper.Repositories;

public sealed class SqlDbConnection
{
    private static SqlDbConnection _instance = null;
    private static IDbConnection _innerConnection = null;
    private static string _connectionString = "";
    private static object _syncObject = new object();

    private SqlDbConnection(string connectionString)
    {
        _connectionString = connectionString;
        _innerConnection = new SqlConnection(connectionString);
        _innerConnection.ConnectionString = connectionString;
        _innerConnection.Open();
    }

    public static string Connection => _connectionString;
    
    public static SqlDbConnection Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_syncObject)
                {
                    _instance = _instance ?? new SqlDbConnection(_connectionString);
                }
            }

            return _instance;
        }
    }
}