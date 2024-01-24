using HospitalApi.Mappers;
using HospitalApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = builder.Configuration.GetConnectionString("HospitalConnection");

builder.Services.AddDbContext<HospitalContext>(o => o.UseSqlServer(ConnectionString));


builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(HospitalProfile));

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
