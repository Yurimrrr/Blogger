using System.Data;
using System.Data.SqlClient;
using Blogger.Extensions.Data.Core.Interfaces;

namespace Blogger.Extensions.Data.Core.Base;

public abstract class RepositoryQueryBase : IRepositoryQueryBase, IDisposable
{
    private IDbConnection _connection;
    private readonly string _connString;

    public RepositoryQueryBase(string connectionString)
    {
        _connString = connectionString;
        _connection = Connection;
    }

    public void Dispose()
    {
        _connection?.Dispose();
        GC.SuppressFinalize(this);
    }
    
    protected IDbConnection Connection
    {
        get
        {
            //if (_connection == null)
            //    _connection = new SqlConnection(_connString);
            //if (_connection.State == ConnectionState.Closed)
            //    _connection.Open();

            return new SqlConnection(_connString);
        }
    }

    public SqlConnection GetConnection()
    {
        return (SqlConnection)Connection;
    }
}