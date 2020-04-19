namespace Core.Database.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; }
        public string Database { get; }
        
        public DatabaseSettings(string connectionString, string database)
        {
            ConnectionString = connectionString;
            Database = database;
        }
    }
}
