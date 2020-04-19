using Core.Database.Settings;
using Core.Users;
using LinqToDB.Data;
using Migration;

namespace DatabaseTest.Configuration
{
    public static class DatabaseSetup
    {
        public static void Setup()
        {
            DatabaseConnection.SetConnection(DatabaseConfiguration.ConnectionString, DatabaseConfiguration.DatabaseName);

            //DatabaseOperations.DropAllObjectsIfDatabaseExists(DatabaseConfiguration.ConnectionString);
            //DatabaseOperations.CreateDatabaseIfNotExists(DatabaseConfiguration.ConnectionString);
            //DatabaseOperations.Upgrade(DatabaseConfiguration.ConnectionString, true);
        }

        public static void Cleanup()
        {
            //DatabaseOperations.DropAllObjectsIfDatabaseExists(DatabaseConfiguration.ConnectionString);
        }

        public static BasicUserData CreateTestUser()
        {
            return new BasicUserData(0, "test");
        }
    }
}
