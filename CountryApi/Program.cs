using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=test.db", b => b.MigrationsAssembly("Application"));
});

builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();

app.Run();
