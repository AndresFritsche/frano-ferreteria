using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using frano_ferreteria;
using Microsoft.OpenApi.Models;

var key = "asidbiabfibiasbdifbaisbdgfbasdngansgnanfgounoindfiogndfignondfgndfgnodnfgoindfingindfg";

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddCors(options =>
{
    options.AddPolicy("dejaloentra", policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization();


// Other services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FranoContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("dejaloentra");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
