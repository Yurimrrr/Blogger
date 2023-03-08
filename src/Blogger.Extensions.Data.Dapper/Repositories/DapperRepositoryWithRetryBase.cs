using System.Data;
using Blogger.Extensions.Data.Dapper.Extensions.RetryPolicy;

namespace Blogger.Extensions.Data.Dapper.Repositories;

public partial class DapperRepositoryWithRetryBase : Data.Dapper.Repositories.DapperRepositoryBase
{
    protected DapperRepositoryWithRetryBase(string connectionString) : base(connectionString) { }

    public override int Execute(
        string query,
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.ExecuteWithRetry(query, param);
        }
    }

    public override object ExecuteScalar(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.ExecuteScalarWithRetry(query, param, transaction, commandTimeout, commandType);
        }
    }

    public override T ExecuteScalar<T>(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.ExecuteScalarWithRetry<T>(query, param, transaction, commandTimeout, commandType);
        }
    }

    public override IEnumerable<T> Query<T>(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        bool buffered = true,
        int? commandTimeout = null, 
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.QueryWithRetry<T>(query, param, transaction, buffered, commandTimeout, commandType);
        }
    }

    public override IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(
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
            return conn.QueryWithRetry<TFirst, TSecond, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public override IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(
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
            return conn.QueryWithRetry<TFirst, TSecond, TThird, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public override IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(
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
            return conn.QueryWithRetry<TFirst, TSecond, TThird, TFourth, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public override IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
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
            return conn.QueryWithRetry<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }
    
    public override IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
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
            return conn.QueryWithRetry<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public override IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
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
            return conn.QueryWithRetry<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(query, map, param, transaction, buffered, splitOn,
                commandTimeout, commandType);
        }
    }

    public override (bool IsSuccess, bool IsExist, TResult? Result) IsExists<TResult>(string query, object? param,
        IDbTransaction? transaction = null) where TResult : default
    {
        try
        {
            using (var conn = Connection)
            {
                var queryResult = conn.QueryWithRetry<TResult>(query, param, transaction).FirstOrDefault();
                
                return (true, queryResult != null, queryResult);
            }
        }
        catch (Exception e)
        {
            return (false, false, default);
        }
    }
}