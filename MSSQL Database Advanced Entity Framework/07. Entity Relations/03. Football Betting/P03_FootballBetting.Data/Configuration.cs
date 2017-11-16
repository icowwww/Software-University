namespace P03_FootballBetting.Data
{
    public class Configuration
    {
        public Configuration(string serverName, string databaseName)
        {
            ServerAndDatabaseConfiguration =
                $@"Server={serverName};Database={databaseName};Integrated Security=True;";
        }

        public string ServerAndDatabaseConfiguration { get; set; }

        public override string ToString()
        {
            return ServerAndDatabaseConfiguration;
        }
    }
}