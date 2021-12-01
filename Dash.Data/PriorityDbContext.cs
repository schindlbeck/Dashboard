using Dash.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Dash.Data
{
    public class PriorityDbContext : DbContext
    {
        public PriorityDbContext(DbContextOptions<PriorityDbContext> options) : base(options)
        {

        }

        public DbSet<Week> Weeks { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class DashDbContextFactorySqLite : IDesignTimeDbContextFactory<PriorityDbContext>
    {
        public PriorityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseSqlite("Data Source=sample.db");

            return new PriorityDbContext(optionsBuilder.Options);
        }
    }


    public class Week
    {
        public int Id { get; set; }
        public int CalendarWeek { get; set; }
        public int Year { get; set; }
        public int ProductionMinutes { get; set; }
        public List<Order> Orders { get; set; } = new();

    }

    public class Order
    {
        public int Id { get; set; }
        public string Key { get; set; }

        public int CurrentCW { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TimeTotal { get; set; }
    }

}
