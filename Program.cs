using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SisacadFinal.Models;
using SisacadFinal.Profiles;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FinalmuContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "My Redis Instance";
    options.Configuration ="localhost:6379";
});


var MisReglasCords = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: MisReglasCords, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MisReglasCords);

app.UseAuthorization();

app.MapControllers();

app.Run();
