using Microsoft.EntityFrameworkCore;
using System;
using UIRSHOP.BL.IRepositories;
using UIRSHOP.BL.Models.Mapping;
using UIRSHOP.BL.Services;
using UIRSHOP.DAL;
using UIRSHOP.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultSqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb")
        );
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped(typeof(UIRSHOP.BL.IRepositories.IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IFactureService, FactureService>();
builder.Services.AddScoped<IDetailsFactureService, DetailsFactureService>();
builder.Services.AddScoped<IOrderproductService, OrderproductService>();

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
