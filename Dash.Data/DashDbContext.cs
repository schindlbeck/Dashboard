using Dash.Shared;
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

        //TODO : Models in Dash.Data
        public DbSet<WorkDay> WorkDays { get; set; }

        //public DbSet<Holidays> Holidays { get; set; }


    }
    public class DashDbContextFactory : IDesignTimeDbContextFactory<DashDbContext>
    {
        public DashDbContext CreateDbContext(string[] args)
        {
           // var configuration = new ConfigurationBuilder()
           //.AddJsonFile("appsettings.json")
           //.Build();

            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            //optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            //optionsBuilder.UseSqlServer(configuration["ConnectionStrings:IntegrationConnection"]);//, b => b.MigrationsAssembly("EMobilityPrototype"));
            //optionsBuilder.UseSqlServer(configuration["ConnectionStrings:FitConnection"]);//, b => b.MigrationsAssembly("EMobilityPrototype"));

            return new DashDbContext(optionsBuilder.Options);
        }
    }
}
