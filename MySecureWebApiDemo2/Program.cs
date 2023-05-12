/*******************
 * 
 *  This project demonstrates implementation of JWT based Token Authentication on Web API
 *  
 *  NOTE: 
 *      To generate a developer user JWT token to test out our API,
 *      make sure that the application is not running.
 *      
 *      Then, open the Developer Command Prompt in the Project folder, and run the following command:
 *          >dotnet user-jwts create
 *      
 *      Apart from the JWT token churned out, then user-jwts tool will add a new section for
 *      the Authentication schema in the appsettings.development.json file!
 *      With the details of the Schema, the Issuer & the Audience!
 *      
 *      To list the data about the token(s)
 *          >dotnet user-jwts list
 *          >dotnet user-jwts print <tokenId>
 *      
 *      You can check out the contents of the JWT Token at https://jwt.io/
 *      
 *      To test the API open PostMan, and in the Headers add:
 *      KEY: "Authorization"
 *      VALUE: "Bearer xxxxxxxx"
 *      
 *********/

// Add the following Nuget Package for providing support for JWT Bearer Tokens
//      Microsoft.AspNetCore.Authentication.JwtBearer

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the Authentication Services (with the JwtBearerToken schema)
builder.Services.AddAuthentication()
                .AddJwtBearer();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
