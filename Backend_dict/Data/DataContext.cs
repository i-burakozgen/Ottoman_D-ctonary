using Backend_dict.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Backend_dict.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Word> Words { get; set; }
    public DbSet<Meaning> Meanings { get; set; }
    public DbSet<Variation> Variations { get; set; }
    public DbSet<PersianTransliteration> PersianTransliterations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Word>()
            .HasMany(m => m.Meanings)
            .WithOne(w => w.Word)
            .HasForeignKey(e => e.WordId);
        modelBuilder.Entity<Word>()
            .HasMany(w => w.Variations)
            .WithOne(v => v.Word)
            .HasForeignKey(f => f.WordId);
        modelBuilder.Entity<Word>()
            .HasMany(p=> p.PersianTransliterations)
            .WithOne(v => v.Word)
            .HasForeignKey(f => f.WordId);
    }
    
}
