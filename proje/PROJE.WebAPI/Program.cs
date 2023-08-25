using PROJE.Business.Implementations;
using PROJE.Business.Interfaces;
using PROJE.DataAccess.Implementations.EF.Repositories;
using PROJE.DataAccess.Interfaces;
using PROJE.WebAPI.Extensions;
using PROJE.WebAPI.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAPIServices(builder.Configuration);


builder.Services.AddControllers()
    .AddJsonOptions(opt=> opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(BookBs));



builder.Services.AddScoped<IBookBs, BookBs>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<ICategoryBs, CategoryBs>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IEmployeeBs, EmployeeBs>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IOrderBs, OrderBs>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IAdminPanelUserBs, AdminPanelUserBs>();
builder.Services.AddScoped<IAdminPanelUserRepository, AdminPanelUserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCostomException();

app.Run();
