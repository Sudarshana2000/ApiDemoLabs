
using Microsoft.EntityFrameworkCore;
using MyWebAppDemo.Data;

namespace MyWebAppDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Register the ApplicationDbContext for Dependency Injection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Extract the connection string from the appsetting.json file
                string? connString
                    = builder.Configuration.GetConnectionString("MyDbConnection");
                if (string.IsNullOrEmpty(connString))
                {
                    throw new Exception("Connection String MyDbConnection has not been configured");
                }

                // Register the ApplicationDbContext to use SQL Server
                options.UseSqlServer(connString);
            });


            builder.Services.AddControllers();

            builder.Services.AddRazorPages();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();     // required for Minimal APIs
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
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

            app.MapControllers();
            app.MapRazorPages();

            // Register ASP.NET Routes for the MVC Controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.Run();
        }
    }
}