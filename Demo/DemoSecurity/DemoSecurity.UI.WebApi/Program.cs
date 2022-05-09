using DemoSecurity.Application.Service.Implementation;
using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Common.SystemVariable.Constant;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IModuleService, ModuleService>();

var app = builder.Build();
// ConnectionString
AppSettingValue.ConnectionDataBase = builder.Configuration.GetConnectionString("SecurityConnection");

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
