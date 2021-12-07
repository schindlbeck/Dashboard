﻿// <auto-generated />
using System;
using Dash.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dash.Data.Migrations
{
    [DbContext(typeof(DashDbContext))]
    [Migration("20211207084413_Priotization")]
    partial class Priotization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("WorkDays");
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

                    b.HasIndex("CalendarWeek", "Year")
                        .IsUnique();

                    b.ToTable("WorkWeeks");
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

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("Dash.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PriorityWeekId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionCW")
                        .HasColumnType("int");

                    b.Property<int>("TimeTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PriorityWeekId");

                    b.ToTable("PriotizedOrders");
                });

            modelBuilder.Entity("Dash.Data.Models.PriorityWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CalendarWeek")
                        .HasColumnType("int");

                    b.Property<int>("ProductionMinutes")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PrioWeeks");
                });

            modelBuilder.Entity("Dash.Data.Models.Order", b =>
                {
                    b.HasOne("Dash.Data.Models.PriorityWeek", null)
                        .WithMany("Orders")
                        .HasForeignKey("PriorityWeekId");
                });

            modelBuilder.Entity("Dash.Data.Models.PriorityWeek", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
