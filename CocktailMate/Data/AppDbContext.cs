using CocktailMate.Models;
using Microsoft.EntityFrameworkCore;

namespace CocktailMate.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }
    
    public virtual DbSet<Cocktail> Cocktails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Database-first scaffolding
        modelBuilder.Entity<Cocktail>(entity =>
        {
            entity.HasKey(e => e.CocktailId).HasName("cocktails_pkey");

            entity.ToTable("cocktails", "cocktail");
            
            entity.Property(e => e.CocktailId)
                .IsRequired()
                .HasColumnName("cocktail_id");
            entity.Property(e => e.Flavour)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("flavour");
            entity.Property(e => e.Garnish)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("garnish");
            entity.Property(e => e.Glass)
                .IsRequired()
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("glass");
            entity.Property(e => e.Ice)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("ice");
            entity.Property(e => e.Ingredients)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("ingredients");
            entity.Property(e => e.Method)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("method");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.Spirit)
                .HasMaxLength(16)
                .HasColumnName("spirit");
        });
    }
}
