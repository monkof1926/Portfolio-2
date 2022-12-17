using DataLayer.Domain;
using WebServer.Middleware;
using DataLayer.DataService;
using DataLayer.IDataService;
using DataLayer.SqlFunctions;

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
builder.Services.AddSingleton<INameSearchFuncDataService, NameSearchFunc>();
builder.Services.AddSingleton<IBestMatchSearchFuncDatService, BestMatchSearchFunc>();
builder.Services.AddSingleton<IExactSearchFuncDataService, ExactSearchFunc>();
builder.Services.AddSingleton<ISimpleSearchFuncDataService, SimpleSearchFunc>();
builder.Services.AddSingleton<IStructuredSearchFuncDataService, StructuredSearchFunc>();



var app = builder.Build();

app.UseAuth();

app.UseCors(
    options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
);

app.MapControllers();

app.Run();
