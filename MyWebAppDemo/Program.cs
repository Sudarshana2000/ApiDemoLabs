using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAppDemo.Data;

// Add the following Nuget Packages for Entity Framework Core support
//      Microsoft.EntityFrameworkCore.SqlServer
//      Microsoft.EntityFrameworkCore.Tools         (for EF Migrations)

// You would need the following Nuget Package for Controller & View Scaffolding
//      Microsoft.VisualStudio.Web.CodeGeneration.Design

// Add the following Nuget Packages for API Documentation Support for Swagger (OpenAPI)
//      Microsoft.AspNetCore.OpenApi
//      Swashbuckle.AspNetCore


// Add the following Assembly-level attribute
//    to ensure that Swagger generates the complete API documentation
[assembly: ApiConventionType(typeof(DefaultApiConventions))]


namespace MyWebAppDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //-----  Add services to the container.

            // Register the ApplicationDbContext for Dependency Injection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Extract the connection string from the appsettings.json file
                string? connString
                    = builder.Configuration.GetConnectionString("MyDbConnection");
                if (string.IsNullOrEmpty(connString))
                {
                    throw new Exception("Connection string MyDbConnection has not been configured");
                }

                // Register the ApplicationDbContext to use SQL Server
                options.UseSqlServer(connString);
            });

            // Register the Output Cache capability 
            // builder.Services.AddOutputCache();

            // Register the Controllers (also needed for Swagger)
            builder.Services.AddControllers();

            builder.Services.AddRazorPages();

            // Register the Swagger (OpenAPI) services 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();         // required for Minimal APIs
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //------- Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Configure the Swagger middleware
                app.UseSwagger();

                // Configure the SwaggerUI middleware
                //    https://localhost:xxxx/swagger/index.html
                //    https://localhost:xxxx/swagger/v1/swagger.json
                app.UseSwaggerUI();
            }
            else
            { 
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();           // Needed to register Controllers (for Swagger also)
            app.MapRazorPages();

            // Register ASP.NET Routes for the MVC Controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.Run();
        }
    }
}