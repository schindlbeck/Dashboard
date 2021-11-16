using Dash.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dash.Data
{
    public class DashDbContext : DbContext
    {
        public DashDbContext(DbContextOptions<DashDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DashDbContext).Assembly);
            //modelBuilder.Entity<User>().HasCheckConstraint("LeavingAfterEntry",
                                                      //$@"[{nameof(User.Leaving)}] IS NULL OR [{nameof(User.Leaving)}] > [{nameof(User.Entry)}]");
        }

        public DbSet<DbWorkDay> WorkDays { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

    }
    public class DashDbContextFactory : IDesignTimeDbContextFactory<DashDbContext>
    {
        public DashDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new DashDbContext(optionsBuilder.Options);
        }
    }
}
