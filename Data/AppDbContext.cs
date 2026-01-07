using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        public DbSet<KanbanTask> Tasks { get; set; }
    }
}