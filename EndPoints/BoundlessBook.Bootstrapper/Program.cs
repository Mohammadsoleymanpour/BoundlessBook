using BoundlessBook.Bootstrapper.Infrastructure;
using BoundlessBook.Bootstrapper.Infrastructure.JwtUtils;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.FileUtil.Services;
using BoundlessBook.Common.Common.AspNetCore;
using BoundlessBook.Config;
using BoundlessBook.Infrastructure;
using BoundlessBook.Presentation.Facade;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterDependency(connectionString);
InfrastructureDI.Init(builder.Services, connectionString);
CommonBootstrapper.Init(builder.Services);
FacadeDI.Init(builder.Services);
DependencyInjection.RegisterDpendency(builder.Services);
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
