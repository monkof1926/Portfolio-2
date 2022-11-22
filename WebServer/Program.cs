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
builder.Services.AddSingleton<IBookmarkPersonDataService, BookmarkPersonDataService>();
builder.Services.AddSingleton<IBookmarkMovieDataService, BookmarkMovieDataService>();
builder.Services.AddSingleton<IRatingPersonDataService, RatingPersonDataService>();
builder.Services.AddSingleton<IRatingMovieDataService, RatingMovieDataService>();
builder.Services.AddSingleton<IRatingHistoryPersonDataService, RatingHistoryPersonDataService>();
builder.Services.AddSingleton<IRatingHistoryMovieDataService, RatingHistoryMovieDataService>();
builder.Services.AddSingleton<ISearchHistoryDataService, SearchHistoryDataService>();


var app = builder.Build();

app.UseAuth();

app.MapControllers();

app.Run();
