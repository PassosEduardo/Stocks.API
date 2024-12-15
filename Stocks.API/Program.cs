using StackExchange.Redis;
using Stocks.API.Infrastructure.Redis;
using Stocks.API.Infrastructure.Repository;
using Stocks.API.Infrastructure.Repository.Brapi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<IStocksRepository, BrapiApiRequester>();
builder.Services.AddTransient<IRedisHandler, RedisHandler>();

builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
    ConnectionMultiplexer.Connect("localhost:6379"));

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
