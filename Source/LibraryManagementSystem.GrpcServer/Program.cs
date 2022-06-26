using LibraryManagementSystem.Core.Implementations;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.GrpcServer.Services;
using LibraryManagementSystem.Infrastructure.Implementations;
using LibraryManagementSystem.Infrastructure.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = builder.Configuration;

builder.Services.AddSingleton<IBookDal, BookDal>(_ => new BookDal(configuration.GetValue<string>("Database:ConnectionString")));
builder.Services.AddSingleton<IBookBl, BookBl>();

builder.Services.AddGrpc();

var repository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
var fileInfo = new FileInfo(@"log4net.config");
log4net.Config.XmlConfigurator.Configure(repository, fileInfo);

var app = builder.Build();

app.MapGrpcService<BooksService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
