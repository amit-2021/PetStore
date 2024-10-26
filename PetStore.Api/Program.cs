using Microsoft.EntityFrameworkCore;
using PetStore.Business.Interfaces;
using PetStore.Business.Services;
using PetStore.DataAccess.Context;
using PetStore.DataAccess.Interfaces;
using PetStore.DataAccess.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

//AppContext.SetSwitch("System.Globalization.Invariant", false);

// Register Services and Repositories
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IPetRepository, PetRepository>();

// Add AutoMapper services


// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
