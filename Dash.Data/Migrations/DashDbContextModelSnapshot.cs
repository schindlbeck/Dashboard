﻿// <auto-generated />
using System;
using Dash.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dash.Data.Migrations
{
    [DbContext(typeof(DashDbContext))]
    partial class DashDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dash.Data.Models.DbWorkDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CalendarWeek")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductionMinutes")
                        .HasColumnType("int");

                    b.Property<string>("WorkDay")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DetailInfo");

                    b.HasKey("Id");

                    b.ToTable("WorkDays", (string)null);
                });

            modelBuilder.Entity("Dash.Data.Models.DbWorkWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CalendarWeek")
                        .HasColumnType("int");

                    b.Property<int>("ProductionMinutes")
                        .HasColumnType("int");

                    b.Property<string>("WorkDays")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DetailInfo");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkWeeks", (string)null);
                });

            modelBuilder.Entity("Dash.Data.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Holidays", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
