using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using TastyTrails.API.Business;
using TastyTrails.API.Repositories;
using TastyTrails.Common.Authorization;
using TastyTrails.Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


builder.Services.AddControllers();

// Authorization
//builder.Services.AddScoped<IUserMetaReader, DefaultUserMetaReader>();
//builder.Services.AddScoped<IPermissionEvaluator, PermissionEvaluator>();

builder.Services.AddRepository();
builder.Services.AddValidators();
builder.Services.AddBusiness();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TastyTrailsDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("TastyTrailsConnection")));

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

app.MapControllers();

app.Run();
