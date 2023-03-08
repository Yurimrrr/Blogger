using System.Data;
using Dapper;

namespace Blogger.Extensions.Data.Dapper.Repositories;

public partial class DapperRepositoryBase
{
    public virtual async Task<int> ExecuteAsync(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.ExecuteAsync(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public virtual async Task<object> ExecuteScalarAsync(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.ExecuteScalarAsync(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public virtual async Task<T> ExecuteScalarAsync<T>(
        string query, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.ExecuteScalarAsync<T>(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public virtual async Task<IEnumerable<T>> QueryAsync<T>(
        string query, 
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return await conn.QueryAsync<T>(query, param, transaction, commandTimeout, commandType);
        }
    }
    
    public virtual async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
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
            return await conn.QueryAsync<TFirst, TSecond, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public virtual async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
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
            return await conn.QueryAsync<TFirst, TSecond, TThird, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public virtual async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
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
            return await conn.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public virtual async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
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
            return await conn.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public virtual async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
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
            return await conn.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }

    public virtual async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
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
            return await conn.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        }
    }
}