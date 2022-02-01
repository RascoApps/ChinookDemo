using Chinook.DataStore.SqlServer;
using Chinook.Service;
using Chinook.Service.Configuration;
using Chinook.Service.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Chinook");
builder.Services
    .AddMediator(cfg => cfg.AddConsumersFromNamespaceContaining<EasyPostConsumer>())
    .AddEasyPostHttpClient()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSqlServer<ChinookContext>(connectionString)
    .AddAutoMapper(cfg => cfg.AddProfile<EasyPostAutoMapperProfile>())
    .AddTransient<IShipmentService,EasyPostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
