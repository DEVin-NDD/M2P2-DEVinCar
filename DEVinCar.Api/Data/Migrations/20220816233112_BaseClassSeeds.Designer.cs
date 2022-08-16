﻿// <auto-generated />
using System;
using DEVinCar.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEVinCar.Api.Data.Migrations
{
    [DbContext(typeof(DevInCarDbContext))]
    [Migration("20220816233112_BaseClassSeeds")]
    partial class BaseClassSeeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DEVinCar.Api.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("SuggestedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cars", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Camaro Chevrolet",
                            SuggestedPrice = 60000m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Maverick Ford",
                            SuggestedPrice = 20000m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Astra Chevrolet",
                            SuggestedPrice = 30000m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hilux Toyota",
                            SuggestedPrice = 20000m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bravo Fiat",
                            SuggestedPrice = 20000m
                        },
                        new
                        {
                            Id = 6,
                            Name = "BR800 Gurgel",
                            SuggestedPrice = 10000m
                        },
                        new
                        {
                            Id = 7,
                            Name = "147 Fiat",
                            SuggestedPrice = 50000m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Del Rey Ford",
                            SuggestedPrice = 10000m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Mustang Ford",
                            SuggestedPrice = 70000m
                        },
                        new
                        {
                            Id = 10,
                            Name = "Belina Ford",
                            SuggestedPrice = 20000m
                        });
                });

            modelBuilder.Entity("DEVinCar.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jose@email.com",
                            Name = "Jose",
                            Password = "12345678"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "andrea@email.com",
                            Name = "Andrea",
                            Password = "12345678"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2005, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "adao@email.com",
                            Name = "Adao",
                            Password = "12345678"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2001, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "monique@email.com",
                            Name = "Monique",
                            Password = "12345678"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
