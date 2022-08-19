﻿// <auto-generated />
using System;
using DEVinCar.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEVinCar.Api.Data.Migrations
{
    [DbContext(typeof(DevInCarDbContext))]
    partial class DevInCarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DEVinCar.Api.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Complement")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses", (string)null);
                });

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

            modelBuilder.Entity("DEVinCar.Api.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryForecast")
                        .HasColumnType("datetime2");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("SaleId");

                    b.ToTable("Deliveries", (string)null);
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("DEVinCar.Api.Models.SaleCar", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("SaleCars", (string)null);
                });

            modelBuilder.Entity("DEVinCar.Api.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("States", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Initials = "AC",
                            Name = "Acre"
                        },
                        new
                        {
                            Id = 2,
                            Initials = "AL",
                            Name = "Alagoas"
                        },
                        new
                        {
                            Id = 3,
                            Initials = "AP",
                            Name = "Amapá"
                        },
                        new
                        {
                            Id = 4,
                            Initials = "AM",
                            Name = "Amazonas"
                        },
                        new
                        {
                            Id = 5,
                            Initials = "BA",
                            Name = "Bahia"
                        },
                        new
                        {
                            Id = 6,
                            Initials = "CE",
                            Name = "Ceará"
                        },
                        new
                        {
                            Id = 7,
                            Initials = "DF",
                            Name = "Distrito Federal"
                        },
                        new
                        {
                            Id = 8,
                            Initials = "ES",
                            Name = "Espírito Santo"
                        },
                        new
                        {
                            Id = 9,
                            Initials = "GO",
                            Name = "Goiás"
                        },
                        new
                        {
                            Id = 10,
                            Initials = "MA",
                            Name = "Maranhão"
                        },
                        new
                        {
                            Id = 11,
                            Initials = "MT",
                            Name = "Mato Grosso"
                        },
                        new
                        {
                            Id = 12,
                            Initials = "MS",
                            Name = "Mato Grosso do Sul"
                        },
                        new
                        {
                            Id = 13,
                            Initials = "MG",
                            Name = "Minas Gerais"
                        },
                        new
                        {
                            Id = 14,
                            Initials = "PA",
                            Name = "Pará"
                        },
                        new
                        {
                            Id = 15,
                            Initials = "PB",
                            Name = "Paraíba"
                        },
                        new
                        {
                            Id = 16,
                            Initials = "PR",
                            Name = "Paraná"
                        },
                        new
                        {
                            Id = 17,
                            Initials = "PE",
                            Name = "Pernambuco"
                        },
                        new
                        {
                            Id = 18,
                            Initials = "PI",
                            Name = "Piauí"
                        },
                        new
                        {
                            Id = 19,
                            Initials = "RJ",
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 20,
                            Initials = "RN",
                            Name = "Rio Grande do Norte"
                        },
                        new
                        {
                            Id = 21,
                            Initials = "RS",
                            Name = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = 22,
                            Initials = "RO",
                            Name = "Rondônia"
                        },
                        new
                        {
                            Id = 23,
                            Initials = "RR",
                            Name = "Roraima"
                        },
                        new
                        {
                            Id = 24,
                            Initials = "SC",
                            Name = "Santa Catarina"
                        },
                        new
                        {
                            Id = 25,
                            Initials = "SP",
                            Name = "São Paulo"
                        },
                        new
                        {
                            Id = 26,
                            Initials = "SE",
                            Name = "Sergipe"
                        },
                        new
                        {
                            Id = 27,
                            Initials = "TO",
                            Name = "Tocantins"
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
                            Password = "123456opp78"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "andrea@email.com",
                            Name = "Andrea",
                            Password = "987dasd654321"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2005, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "adao@email.com",
                            Name = "Adao",
                            Password = "2589asd"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2001, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "monique@email.com",
                            Name = "Monique",
                            Password = "asd45uio"
                        });
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Address", b =>
                {
                    b.HasOne("DEVinCar.Api.Models.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.City", b =>
                {
                    b.HasOne("DEVinCar.Api.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Delivery", b =>
                {
                    b.HasOne("DEVinCar.Api.Models.Address", "Address")
                        .WithMany("Deliveries")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinCar.Api.Models.Sale", "Sale")
                        .WithMany("Deliveries")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Sale", b =>
                {
                    b.HasOne("DEVinCar.Api.Models.User", "UserBuyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinCar.Api.Models.User", "UserSeller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserBuyer");

                    b.Navigation("UserSeller");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.SaleCar", b =>
                {
                    b.HasOne("DEVinCar.Api.Models.Car", "Car")
                        .WithMany("Sales")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinCar.Api.Models.Sale", "Sale")
                        .WithMany("Cars")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Address", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Car", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.Sale", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("DEVinCar.Api.Models.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
