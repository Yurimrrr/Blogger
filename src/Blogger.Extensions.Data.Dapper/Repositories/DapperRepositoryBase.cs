using System.Data;
using System.Data.SqlClient;
using Blogger.Extensions.Data.Core.Interfaces;
using Dapper;

namespace Blogger.Extensions.Data.Dapper.Repositories;

public abstract partial class DapperRepositoryBase : IRepositoryBase
{
    private bool _disposedValue;
    private string _connectionString;
    private IDbConnection _connection;
    
    protected IDbConnection Connection
    {
        get
        {
            if (_connection == null)
                _connection = new SqlConnection(_connectionString);
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            return _connection;
        }
    }
    protected IDbTransaction Transaction { get; set; }
    
    public DapperRepositoryBase(string connectionString)
    {
        _connectionString = connectionString;
    }

    #region UnitOfWork
    public IDbTransaction BeginTransaction()
    {
        Transaction = Connection.BeginTransaction();
        return Transaction;
    }

    public void Commit()
    {
        if (Connection.State != ConnectionState.Open)
            Connection.Open();
        
        Transaction.Commit();
        Dispose();
    }

    public void Rollback()
    {
        Transaction.Rollback();
        Dispose();
    }
    #endregion
    
    public virtual int Execute(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Execute(query, param, transaction, commandTimeout, commandType);
        }
        
    }
    
    public virtual object ExecuteScalar(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.ExecuteScalar(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public virtual T ExecuteScalar<T>(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.ExecuteScalar<T>(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public virtual IEnumerable<T> Query<T>(
        string query, 
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<T>(query, param, transaction, buffered, commandTimeout, commandType);
        }
    }

    public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(
        string query, 
        Func<TFirst, TSecond, TReturn> map, 
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<TFirst, TSecond, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(
        string query, 
        Func<TFirst, TSecond, TThird, TReturn> map, 
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<TFirst, TSecond, TThird, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(
        string query, 
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map, 
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<TFirst, TSecond, TThird, TFourth, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        string query, 
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, 
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
        string query, 
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, 
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
        string query, 
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }


    public virtual (bool IsSuccess, bool IsExist, TResult? Result) IsExists<TResult>(
        string query, 
        object? param,
        IDbTransaction? transaction = null) 
    {
        try
        {
            using (var conn = Connection)
            {
                var queryResult = conn.Query<TResult>(query, param, transaction).FirstOrDefault();
            
                return (true, queryResult != null, queryResult);
            }
        }
        catch (Exception e)
        {
            return (false, false, default);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
            _connection.Close();
    }
}