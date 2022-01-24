namespace Directory.CLI.Data;

using Directory.CLI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


public class DirectoryDbContext : DbContext
{
#nullable disable
    public DirectoryDbContext(DbContextOptions<DirectoryDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DirectorySize>().HasKey(p => p.Id);
        modelBuilder.Entity<DirectorySize>().Property(p => p.Year).HasMaxLength(4);
    }

    public DbSet<DirectorySize> DirectorySizes { get; set; }
}

public class DirectoryDbContextFactory : IDesignTimeDbContextFactory<DirectoryDbContext>
{
    public DirectoryDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json")
       .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DirectoryDbContext>();
        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

        return new DirectoryDbContext(optionsBuilder.Options);
    }
}
