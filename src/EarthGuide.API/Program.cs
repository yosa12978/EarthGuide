using EarthGuide.API.Endpoints;
using EarthGuide.Data;
using EarthGuide.Data.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

//builder.Services.UseInMemoryDb();
builder.Services.UseSqliteDb(
    builder.Configuration.GetValue<string>("Sqlite:ConnectionString"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseUserEndpoints();
app.UseRestaurantEndpoints();
app.UseSightplaceEndpoints();

app.UseAuthentication();
app.UseAuthorization();


// FOR WHOLE DAPPER DBs
var db = app.Services.GetRequiredService<DatabaseInitializer>();
await db.Initialize();

app.Run();
