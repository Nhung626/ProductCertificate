using HoangHongNhung152465.DbContexts;
using HoangHongNhung152465.Services.Implements;
using HoangHongNhung152465.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext152465De2>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
 builder.Services.AddScoped<IProductService152465De2, ProductService152465De2>();
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
