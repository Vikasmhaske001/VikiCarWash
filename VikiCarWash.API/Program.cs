using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Application.Mappings;
using VikiCarWash.Application.Services;
using VikiCarWash.Infrastructure.Data;
using VikiCarWash.Infrastructure.Repositories;
using VikiCarWash.Infrastructure.Services;
using VikiCarWash.API.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using VikiCarWash.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<ICarWashBookingRepository, CarWashBookingRepository>();
builder.Services.AddScoped<ICarWashBookingService, CarWashBookingService>();
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
