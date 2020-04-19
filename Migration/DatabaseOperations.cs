using DbUp;
using Npgsql;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Migration
{
    public static class DatabaseOperations
    {
        public static void Upgrade(string connectionString, bool skipMigrationLogs = false)
        {
            //UpgradeBase(connectionString, name => name.Contains("Scripts"), skipMigrationLogs);
        }

        public static void DropAllObjectsIfDatabaseExists(string connectionString)
        {
            //bool databaseExists = TryConnect(connectionString);

            //if (!databaseExists) return;

            //string command =
            //    "drop schema if exists pallets cascade;" +
            //    "drop table if exists public.schemaversions;";

            //using (var dbConnection = new NpgsqlConnection(connectionString))
            //using (var dbCommand = new NpgsqlCommand(command, dbConnection))
            //{
            //    try
            //    {
            //        dbConnection.Open();
            //        dbCommand.ExecuteNonQuery();
            //        return;
            //    }
            //    catch (NpgsqlException ex)
            //    {
            //        throw new InvalidOperationException($"Cannot drop objects", ex);
            //    }
            //}
        }

        //public static void CreateDatabaseIfNotExists(string connectionString)
        //{
        //    bool databaseExists = TryConnect(connectionString);

        //    if (databaseExists) return;

        //    var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        //    var dbName = connectionStringBuilder.Database;
        //    connectionStringBuilder.Database = "postgres";

        //    var postgresDbConnectionString = connectionStringBuilder.ConnectionString;

        //    WaitForConnection(postgresDbConnectionString, 30);

        //    using (var dbConnection = new NpgsqlConnection(postgresDbConnectionString))
        //    using(var dbCommand = new NpgsqlCommand($"Create database {dbName};", dbConnection))
        //    {
        //        try
        //        {
        //            dbConnection.Open();
        //            dbCommand.ExecuteNonQuery();
        //            return;
        //        }
        //        catch(NpgsqlException ex)
        //        {
        //            throw new InvalidOperationException($"Cannot create database: {dbName}", ex);
        //        }
        //    }

        //}

        //private static void WaitForConnection(string connectionString, int timeoutSeconds)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();

        //    while(stopwatch.Elapsed.Seconds < timeoutSeconds)
        //    {
        //        if(TryConnect(connectionString))
        //        {
        //            return;
        //        }
        //        Thread.Sleep(2000);
        //    }

        //    throw new InvalidOperationException("Unable to connect to database");
        //}

        //private static bool TryConnect(string connectionString)
        //{
        //    using( var connection = new NpgsqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //}

        //private static void UpgradeBase(string connectionString, Func<string, bool> filter, bool skipMigrationLogs = false)
        //{
        //    WaitForConnection(connectionString, 30);

        //    var upgradeEngineBuilder = DeployChanges.To
        //        .PostgresqlDatabase(connectionString)
        //        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), filter)
        //        .WithVariablesDisabled();

        //    if (skipMigrationLogs)
        //    {
        //        upgradeEngineBuilder.LogToNowhere();
        //    }
        //    else
        //    {
        //        upgradeEngineBuilder.LogToConsole();
        //    }

        //    var upgradeEngine = upgradeEngineBuilder.Build();
        //    var result = upgradeEngine.PerformUpgrade();

        //    if(result.Error != null)
        //    {
        //        throw new InvalidOperationException("Database upgrade error", result.Error);
        //    }
        //}

        //public static void RunScript(string connectionString, string script)
        //{
        //    using (var dbConnection = new NpgsqlConnection(connectionString))
        //    using (var dbCommand = new NpgsqlCommand(script, dbConnection))
        //    {
        //        dbConnection.Open();
        //        dbCommand.ExecuteNonQuery();
        //    }
        //}
    }
}
