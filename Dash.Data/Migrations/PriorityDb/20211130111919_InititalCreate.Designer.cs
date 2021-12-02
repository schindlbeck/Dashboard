﻿// <auto-generated />
using System;
using Dash.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dash.Data.Migrations.PriorityDb
{
    [DbContext(typeof(PriorityDbContext))]
    [Migration("20211130111919_InititalCreate")]
    partial class InititalCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Dash.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeTotal")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeekId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeekId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Dash.Data.Week", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalendarWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductionMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Weeks");
                });

            modelBuilder.Entity("Dash.Data.Order", b =>
                {
                    b.HasOne("Dash.Data.Week", null)
                        .WithMany("Orders")
                        .HasForeignKey("WeekId");
                });

            modelBuilder.Entity("Dash.Data.Week", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
