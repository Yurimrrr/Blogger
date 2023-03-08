using System.Data;
using Blogger.Extensions.Data.Dapper.Extensions.RetryPolicy;

namespace Blogger.Extensions.Data.Dapper.Repositories;

public partial class DapperRepositoryWithRetryBase
{
    public override async Task<int> ExecuteAsync(
        string query,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.ExecuteWithRetryAsync(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public override async Task<object> ExecuteScalarAsync(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.ExecuteScalarWithRetryAsync(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public override async Task<T> ExecuteScalarAsync<T>(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.ExecuteScalarWithRetryAsync<T>(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public override async Task<IEnumerable<T>> QueryAsync<T>(
        string query, 
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.QueryWithRetryAsync<T>(query, param, transaction, commandTimeout, commandType);
        }
    }

    public override async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
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
            return await conn.QueryWithRetryAsync<TFirst, TSecond, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }
    
    public override async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
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
            return await conn.QueryWithRetryAsync<TFirst, TSecond, TThird, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public override async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
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
            return await conn.QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public override async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
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
            return await conn.QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public override async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
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
            return await conn.QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public override async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
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
            return await conn.QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

}