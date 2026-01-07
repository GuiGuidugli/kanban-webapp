using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
    {
    }

    public DbSet<KanbanTask> KanbanTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<KanbanTask>(entity =>
        {
            // Set Id as the primary key
            entity.HasKey(e => e.Id);

            // Configure Title as required with max length
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            // Configure Description with max length
            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            // Configure Status as required
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Set default value for CreatedAt
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("datetime('now')");
        });
    }
}