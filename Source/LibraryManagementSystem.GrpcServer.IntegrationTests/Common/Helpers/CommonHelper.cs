using Grpc.Net.Client;
using LibraryManagementSystem.GrpcServer.IntegrationTests.Common.AppSettings;
using Microsoft.Extensions.Configuration;

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
    }
}
