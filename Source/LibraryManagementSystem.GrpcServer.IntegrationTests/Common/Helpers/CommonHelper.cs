using Grpc.Net.Client;
using LibraryManagementSystem.GrpcServer.IntegrationTests.Common.AppSettings;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.GrpcServer.IntegrationTests.Common.Helpers
{
    public class CommonHelper
    {
        public readonly Settings Settings;
        public readonly Books.BooksClient BooksClient;

        public CommonHelper()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Settings = new Settings();
            configuration.Bind(Settings);

            var channel = GrpcChannel.ForAddress(Settings.GrpcServer.Url);
            BooksClient = new Books.BooksClient(channel);
        }

        public static async Task AddTestDataToDatabase(SqlCommand sqlCommand)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentParentDirectory = Directory.GetParent(currentDirectory);
            var sourceDirectory = currentParentDirectory?.Name;
            var databaseDirectory = "";

            while (sourceDirectory != "Source")
            {
                currentParentDirectory = Directory.GetParent(currentParentDirectory?.FullName!);
                sourceDirectory = currentParentDirectory?.Name;

                if (sourceDirectory == "Source")
                {
                    databaseDirectory = $@"{currentParentDirectory?.Parent?.FullName}\Database\Manual Scripts";
                }
            }

            var insertSqlFiles = Directory.GetFiles(databaseDirectory).Where(x => x.Contains("insert_into"));

            foreach (var insertSqlFile in insertSqlFiles)
            {
                var sqlText = await File.ReadAllTextAsync(insertSqlFile);

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlText;
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }
    }
}
