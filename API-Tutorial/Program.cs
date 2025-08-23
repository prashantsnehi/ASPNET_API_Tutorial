using API_Tutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;
using API_Tutorial.Filters;
using API_Tutorial.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ServiceConfiguration(builder.Configuration);

builder.Services.AddControllers(options =>
{
#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
    var logger = builder.Services
        .BuildServiceProvider()
        .GetRequiredService<ILogger<ResponseHeaderFilter>>();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'

    options.Filters.Add(new ResponseHeaderFilter(logger,"X-Developer-Info", "Prashant Kumar Snehi"));
 });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

