using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SisacadFinal.Models;
using SisacadFinal.Profiles;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Identity.Web;
using SisacadFinal;
using Microsoft.AspNetCore.Authorization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FinalmuContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql")));

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");
var secreckey = builder.Configuration.GetSection("settings").GetSection("secreckey").ToString();

var keyBytes = Encoding.UTF8.GetBytes(secreckey);








builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://login.microsoftonline.com/f914fef4-29a5-4c7f-b8dd-4acb2290ac86";
        options.Audience = "c929fbec-5e46-41f3-b4f4-a61b9297bfd5";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = $"https://login.microsoftonline.com/f914fef4-29a5-4c7f-b8dd-4acb2290ac86",
            ValidAudience = "c929fbec-5e46-41f3-b4f4-a61b9297bfd5"
        };
    });







builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddStackExchangeRedisCache(options =>
{

    options.InstanceName = "cacheFirstDD";
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
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


if (app.Environment.IsDevelopment() || app.Environment.IsProduction())

{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MisReglasCords);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
