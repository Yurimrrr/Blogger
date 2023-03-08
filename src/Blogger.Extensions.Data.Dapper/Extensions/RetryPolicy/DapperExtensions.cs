using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Blogger.Extensions.Data.Core.Exceptions;
using Dapper;
using Polly;
using Polly.Retry;

namespace Blogger.Extensions.Data.Dapper.Extensions.RetryPolicy;

public static partial class DapperExtensions
{
    private static readonly IEnumerable<TimeSpan> RetryTimes = new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(2),
        TimeSpan.FromSeconds(3)
    };
    
    private static readonly global::Polly.Retry.RetryPolicy RetryPolicy = Policy
        .Handle<SqlException>(SqlServerTransientExceptionDetector.ShouldRetryOn)
        .Or<TimeoutException>()
        .OrInner<Win32Exception>(SqlServerTransientExceptionDetector.ShouldRetryOn)
        .WaitAndRetry(RetryTimes, 
            (currentException, currentSleepDuration, currentRetryNumber, currentContext) =>
            {
                Console.WriteLine($@"{nameof(currentException)}: {currentException} - 
                    {nameof(currentSleepDuration)}: {currentSleepDuration} -
                    {nameof(currentRetryNumber)}: {currentRetryNumber} -  
                    {nameof(currentContext)}: {currentContext}");
#if DEBUG
                Debug.WriteLine($"=== Attempt {currentRetryNumber} ===");
                Debug.WriteLine($"{nameof(currentException)}: {currentException}");
                Debug.WriteLine($"{nameof(currentSleepDuration)}: {currentSleepDuration}");
                Debug.WriteLine($"{nameof(currentRetryNumber)}: {currentRetryNumber}");
                Debug.WriteLine($"{nameof(currentContext)}: {currentContext}");
#endif
            });
    
    private static readonly AsyncRetryPolicy AsyncRetryPolicy = Policy
        .Handle<SqlException>(SqlServerTransientExceptionDetector.ShouldRetryOn)
        .Or<TimeoutException>()
        .OrInner<Win32Exception>(SqlServerTransientExceptionDetector.ShouldRetryOn)
        .WaitAndRetryAsync(RetryTimes, 
            (currentException, currentSleepDuration, currentRetryNumber, currentContext) =>
            {
                Console.WriteLine($@"{nameof(currentException)}: {currentException} - 
                    {nameof(currentSleepDuration)}: {currentSleepDuration} -
                    {nameof(currentRetryNumber)}: {currentRetryNumber} -  
                    {nameof(currentContext)}: {currentContext}");
#if DEBUG
                Debug.WriteLine($"=== Attempt {currentRetryNumber} ===");
                Debug.WriteLine($"{nameof(currentException)}: {currentException}");
                Debug.WriteLine($"{nameof(currentSleepDuration)}: {currentSleepDuration}");
                Debug.WriteLine($"{nameof(currentRetryNumber)}: {currentRetryNumber}");
                Debug.WriteLine($"{nameof(currentContext)}: {currentContext}");
#endif
            });


    public static SqlConnection OpenWithRetry(this IDbConnection cnn) => (SqlConnection)RetryPolicy.Execute(() =>
    {
        if (cnn.State != ConnectionState.Open)
            cnn.Open();

        return cnn;
    });
    
    public static int ExecuteWithRetry(this IDbConnection cnn, string query, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open) 
                cnn.Open();
            
            return cnn.Execute(query, param, transaction, commandTimeout, commandType);
        });

    public static object ExecuteScalarWithRetry(this IDbConnection cnn, 
        string query, 
        object? param = null,
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.ExecuteScalar(query, param, transaction, commandTimeout, commandType);
        });

    public static T ExecuteScalarWithRetry<T>(this IDbConnection cnn, 
        string query, 
        object? param = null,
        IDbTransaction? transaction = null, 
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.ExecuteScalar<T>(query, param, transaction, commandTimeout, commandType);
        });

    public static IEnumerable<T> QueryWithRetry<T>(this IDbConnection cnn, 
        string query, 
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open) 
                cnn.Open();
            
            return cnn.Query<T>(query, param, transaction, buffered, commandTimeout, commandType);
        });

    public static IEnumerable<TReturn> QueryWithRetry<TFirst, TSecond, TReturn>(this IDbConnection cnn, string query,
        Func<TFirst, TSecond, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.Query<TFirst, TSecond, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static IEnumerable<TReturn> QueryWithRetry<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn,
        string query,
        Func<TFirst, TSecond, TThird, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.Query<TFirst, TSecond, TThird, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static IEnumerable<TReturn> QueryWithRetry<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn,
        string query,
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.Query<TFirst, TSecond, TThird, TFourth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static IEnumerable<TReturn> QueryWithRetry<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        this IDbConnection cnn,
        string query,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static IEnumerable<TReturn> QueryWithRetry<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
        this IDbConnection cnn,
        string query,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

    public static IEnumerable<TReturn> QueryWithRetry<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh,
        TReturn>(this IDbConnection cnn,
        string query,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null,
        bool buffered = true,
        string splitOn = "Id",
        int? commandTimeout = null,
        CommandType? commandType = null) => RetryPolicy.Execute(() =>
        {
            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            return cnn.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(query, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
        });

}