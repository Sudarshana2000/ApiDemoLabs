/*******************
 * 
 *  This project demonstrates implementation of Basic Authentication on Web API
 *      
 *********/

using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using MySecureWebApiDemo.Handlers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "basic",
        Type = SecuritySchemeType.Http,
        Description = "Basic Authentication using http security scheme"
    });

    o.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                    ("BasicAuthentication", null);


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
