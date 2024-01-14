using CleanArch_CRUD.Domain.Interfaces;
using CleanArch_CRUD.Infrastructure.Context;
using CleanArch_CRUD.Services.IServices;
using CleanArch_CRUD.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using CleanArch_CRUD.Domain.Models;
using CleanArch_CRUD.Domain.Interfaces.ICategoryRepo;
using CleanArch_CRUD.Infrastructure.Repositories.CategoryRepo;
using CleanArch_CRUD.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IBaseRepository<Category>, BaseRepository<Category>>();

builder.Services.AddDbContext<AppDbContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));


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
