using System.Text.Json.Serialization;
using WSP.Business.Implementations;
using WSP.Business.Interfaces;
using WSP.DataAccess.Implementations.EF.Repositories;
using WSP.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
                                 opt.JsonSerializerOptions.ReferenceHandler =
                                 ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(BookBs));


builder.Services.AddScoped <IBookBs, BookBs>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IPublisherBs, PublisherBs>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();

builder.Services.AddScoped<IBTypeBs, BTypeBs>();
builder.Services.AddScoped<IBTypeRepository, BTypeRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
