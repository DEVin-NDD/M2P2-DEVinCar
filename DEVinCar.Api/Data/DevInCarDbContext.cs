using DEVinCar.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Api.Data;

public class DevInCarDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DevInCarDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //public DbSet<XYZ> XYZs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleCar> SaleCars { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _configuration.GetConnectionString("DEV_IN_CAR")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Exemplo
        // modelBuilder.Entity<XYZ>(entidade =>
        // {
        //     entidade.ToTable("[XYZ]s");

        //     entidade.HasKey(a => a.Id);

        //     entidade
        //         .Property(a => a.[prop])
        //         .HasMaxLength(120)
        //         .IsRequired();

        //     entidade
        //         .HasData(new[]{
        //             ...
        //         });
        // });
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id);
            entity
                .Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();

            entity
                .Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity
                .Property(u => u.BirthDate);
            entity
                .HasData(new[] {
                    new User (1, "jose@email.com", "123456opp78", "Jose", new DateTime(2000, 12, 10)),
                    new User (2, "andrea@email.com", "987dasd654321", "Andrea", new DateTime(1999, 05, 11)),
                    new User (3, "adao@email.com", "2589asd", "Adao", new DateTime(2005, 09, 02)),
                    new User (4, "monique@email.com", "asd45uio", "Monique", new DateTime(2001, 06, 07)),
                });
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("Cars");
            entity.HasKey(c => c.Id);

            entity
                .Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity
                .Property(c => c.SuggestedPrice);

            entity
                .HasData(new[] {
                    new Car (1, "Camaro Chevrolet", 60000M),
                    new Car (2, "Maverick Ford", 20000M),
                    new Car (3, "Astra Chevrolet", 30000M),
                    new Car (4, "Hilux Toyota", 20000M),
                    new Car (5, "Bravo Fiat", 20000M),
                    new Car (6, "BR800 Gurgel", 10000M),
                    new Car (7, "147 Fiat", 50000M),
                    new Car (8, "Del Rey Ford", 10000M),
                    new Car (9, "Mustang Ford", 70000M),
                    new Car (10, "Belina Ford", 20000M)
                });
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sales");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id)
                .HasColumnType("int");

            entity.Property(s => s.BuyerId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(s => s.SellerId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(s => s.SaleDate)
                .HasColumnType("timestamp");

        });

        modelBuilder.Entity<SaleCar>(entity =>
        {
            entity.ToTable("SaleCars");
            entity.HasKey(sc => sc.Id);
            entity.Property(sc => sc.Id)
                .HasColumnType("int");

            entity.Property(s => s.SaleId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(s => s.CarId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(s => s.UnitPrice)
                .HasColumnType("timestamp");


        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.ToTable("Deliveries");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.Id)
                .HasColumnType("int");

            entity.Property(d => d.AddressId)
                .HasColumnType("int");


            entity
                .Property(d => d.SaleId)
                .HasColumnType("int");


            entity
                .Property(d => d.DeliveryForecast)
                .HasColumnType("timestamp");
        });
    }
}