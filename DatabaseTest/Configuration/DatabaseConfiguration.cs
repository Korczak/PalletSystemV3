using System.IO;

namespace DatabaseTest.Configuration
{
    static class DatabaseConfiguration
    {
        public static string ConnectionString { get; }
        public static string DatabaseName { get; }

        public const int DATABASE_PORT = 8885;

        static DatabaseConfiguration()
        {
            ConnectionString = GetDatabaseMode();
            DatabaseName = "TestDatabase";
        }

        private static string GetDatabaseMode()
        {
            string connectionStringFilePath = FindConnectionStringFile();

            if (connectionStringFilePath != null)
            {
                string connectionString = File.ReadAllText(connectionStringFilePath);
                return connectionString;
            }
            return null;
        }

        private static string FindConnectionStringFile(int tryLimit = 5)
        {
            string path = Directory.GetCurrentDirectory();

            int iteration = 0;

            while (iteration < tryLimit)
            {
                string tryPath = Path.Combine(path, "ConnectionString.txt");

                if (File.Exists(tryPath))
                {
                    return tryPath;
                }
                else
                {
                    path = Path.Combine(path, "..");
                }

                ++iteration;
            }

            return null;
        }
    }

}
