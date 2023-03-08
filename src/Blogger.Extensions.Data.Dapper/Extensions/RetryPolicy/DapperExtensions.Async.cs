using System.Data;
using Dapper;

namespace Blogger.Extensions.Data.Dapper.Extensions.RetryPolicy;

public static partial class DapperExtensions
{
    public static Task<int> ExecuteWithRetryAsync(this IDbConnection cnn,
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        });

    public static Task<object> ExecuteScalarWithRetryAsync(this IDbConnection cnn,
        string query, 
        object? param = null,
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.ExecuteScalarAsync(query, param, transaction, commandTimeout, commandType);
        });

    public static Task<T> ExecuteScalarWithRetryAsync<T>(this IDbConnection cnn,
        string query, 
        object? param = null,
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.ExecuteScalarAsync<T>(query, param, transaction, commandTimeout, commandType);
        });

    public static Task<IEnumerable<T>> QueryWithRetryAsync<T>(this IDbConnection cnn,
        string query,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.QueryAsync<T>(query, param, transaction, commandTimeout, commandType);
        });

    public static Task<IEnumerable<TReturn>> QueryWithRetryAsync<TFirst, TSecond, TReturn>(this IDbConnection cnn,
        string query,
        Func<TFirst, TSecond, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.QueryAsync(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static Task<IEnumerable<TReturn>> QueryWithRetryAsync<TFirst, TSecond, TThird, TReturn>(
        this IDbConnection cnn,
        string sql,
        Func<TFirst, TSecond, TThird, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static Task<IEnumerable<TReturn>> QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
        this IDbConnection cnn,
        string sql,
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static Task<IEnumerable<TReturn>> QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        this IDbConnection cnn,
        string sql,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static Task<IEnumerable<TReturn>> QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth,
        TSeventh, TReturn>(this IDbConnection cnn,
        string sql,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static Task<IEnumerable<TReturn>> QueryWithRetryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth,
        TReturn>(this IDbConnection cnn,
        string sql,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => AsyncRetryPolicy.ExecuteAsync(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

}