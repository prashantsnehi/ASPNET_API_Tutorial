using API_Tutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;
using API_Tutorial.Filters;
using API_Tutorial.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ServiceConfiguration(builder.Configuration);

builder.Services.AddControllers(options =>
{
    var logger = builder.Services
        .BuildServiceProvider()
        .GetRequiredService<ILogger<ResponseHeaderFilter>>();

    //// specify the order of the execution in generic declaration
    //options.Filters.Add<ResponseHeaderFilter>(4);

    options.Filters.Add(new ResponseHeaderFilter(logger, "X-Developer-Info", "Prashant Kumar Snehi", 0));
    options.Filters.Add(new ResponseHeaderAsyncFilter(builder.Services.BuildServiceProvider()
        .GetRequiredService<ILogger<ResponseHeaderAsyncFilter>>(), "X-ExecutionStart-Info", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0));
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

