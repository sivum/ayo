using Ayo.Api;
using Ayo.Api.Data;
using Ayo.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<ConversionDbContext>(o=>
    o.UseNpgsql(@"Host=localhost;Username=postgres;Password=root;Database=postgres"));
builder.Services.AddTransient<ConversionService>();
builder.Services.AddTransient<MetricImperialFactory>();
builder.Services.AddTransient<IConversionRateRepository, ConversionRateRepository>();
builder.Services.AddControllers();
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