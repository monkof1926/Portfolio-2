using DataLayer.Domain;
using DataLayer.DataService;
using DataLayer.IDataService;
using WebServer.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IUserDataService, UserDataService>();
builder.Services.AddSingleton<IPersonDataService, PersonDataService>();
builder.Services.AddSingleton<IMovieDataService, MovieDataService>();
builder.Services.AddSingleton<IBookmarkDataService, BookmarkDataService>();
builder.Services.AddSingleton<IRatingDataService, RatingDataService>();
builder.Services.AddSingleton<IRatingHistoryDataService, RatingHistoryDataService>();
builder.Services.AddSingleton<ISearchHistoryDataService, SearchHistoryDataService>();


var app = builder.Build();

app.UseAuth();

app.MapControllers();

app.Run();
