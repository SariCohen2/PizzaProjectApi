using interfacesLib;
using servicesLib;
using modelsLib;
using FileService;
using Extensions;
using middleware;

using System;
using System.Collections.Generic;
using Microsoft;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options=>
{
     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.TokenValidationParameters = TokenService.GetTokenValidationParameters();
});

builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("Admin", policy => policy.RequireClaim("UserType", "Admin"));
    cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("UserType", "SuperWorker"));
    // cfg.AddPolicy("principal", policy => policy.RequireClaim("UserType", "principal"));

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "core", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your Task JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }});
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPizzaShopServices,PizzaShopServices>();
builder.Services.AddSingleton<IOrderPizza,OrderPizzaService>();
builder.Services.AddTransient<IWorkers,WorkersService>();
builder.Services.AddScoped<IToken,TokenService>();

builder.Services.AddSingleton<Ilog,myLog>();
builder.Services.AddSingleton<Ifile,myFile>();
builder.Services.AddSingleton<IWorker,myWorker>();
builder.Services.AddSingleton<IMail,myMail>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseErrorHandler();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseActionLog();
app.Run();

