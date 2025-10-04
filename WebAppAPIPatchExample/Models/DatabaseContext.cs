using Microsoft.EntityFrameworkCore;

namespace WebAppAPIPatchExample.Models
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<People> People { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(x =>
            {
                x.ToTable("people");
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).HasColumnName("id");
                x.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
                x.Property(x => x.Status).HasColumnName("status");
            });
        }
    }
}
