﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartsHunter.Data;

#nullable disable

namespace PartsHunter.Migrations
{
    [DbContext(typeof(PartsHunterContext))]
    partial class PartsHunterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("PartsHunter.Data.Entities.ComponentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("SlotID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("PartsHunter.Data.Entities.HardwareDeviceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IP")
                        .HasColumnType("TEXT");

                    b.Property<int>("blinky_ms")
                        .HasColumnType("INTEGER");

                    b.Property<int>("blue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("brightness")
                        .HasColumnType("INTEGER");

                    b.Property<int>("green")
                        .HasColumnType("INTEGER");

                    b.Property<int>("red")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("HardwareDevice", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
