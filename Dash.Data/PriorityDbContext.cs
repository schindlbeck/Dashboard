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
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Order> Orders { get; set; }

        public string DbPath { get; private set; }

        public PriorityDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}priority.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }


    public class Week
    {
        public int Id { get; set; }
        public int CalendarWeek { get; set; }
        public int Year { get; set; }
        public int ProductionMinutes { get; set; }
        public List<Order> Orders { get; set; }

    }

    public class Order
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TimeTotal { get; set; }
    }


}
