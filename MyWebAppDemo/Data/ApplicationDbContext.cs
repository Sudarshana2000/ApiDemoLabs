using Microsoft.EntityFrameworkCore;
using MyWebAppDemo.Models;

namespace MyWebAppDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

    }
}
