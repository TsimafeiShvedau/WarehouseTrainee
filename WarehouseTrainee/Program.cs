using Microsoft.EntityFrameworkCore;
using Warehouse.DAL.Data;
using Warehouse.DAL.DataModels;
using Warehouse.DAL.Repositories;
using Warehouse.DAL.Repositories.Interfaces;
using WarehouseTrainee.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



var connectionString = builder.Configuration.GetConnectionString("WarehouseDB");
builder.Services.AddDbContext<WarehouseDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IRepository<Department>, DepartmentsRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepository<Product>, ProductsRepository>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IRepository<Worker>, WorkersRepository>();


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
