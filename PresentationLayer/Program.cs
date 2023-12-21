using ApplicationLayer.AutoMapper;
using ApplicationLayer.IServices;
using ApplicationLayer.Services;
using AutoMapper;
using DomainLayer.Interface;
using DomainLayer.Interface.Repository;
using InfrastructureLayer.Context;
using InfrastructureLayer.Persistance.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DataContext>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddTransient<DapperContext>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICustomerService, CustomerServices>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepoDapper>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();



var autoMapper = new MapperConfiguration(item => item.AddProfile(new MapperProfile()));
IMapper mapper =autoMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

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



