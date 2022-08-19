using Microsoft.EntityFrameworkCore;

namespace Ayo.Api.Data;

public class ConversionDbContext:DbContext
{
    public ConversionDbContext(DbContextOptions<ConversionDbContext> options)
        :base(options)
    {

    }

    public DbSet<ConversionRateModel> ConversionRates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConversionRateModel>(entity =>
        {
            entity.ToTable("conversion_rates");
            entity.HasKey(e => e.id);
            entity.Property(e => e.source).IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.target).IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.value).IsRequired();
        });
        
        base.OnModelCreating(modelBuilder);
    }

    
}