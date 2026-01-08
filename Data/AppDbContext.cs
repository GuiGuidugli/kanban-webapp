using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base (options)
    {
    }
    
    public DbSet<KanbanTask> KanbanTasks { get; set; }

    public override int SaveChanges()
    {   
        UpdateTimestamps();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<KanbanTask>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("datetime('now')");
            
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("datetime('now')");
        });
    }

    private void UpdateTimestamps()
    {
       
    }
}