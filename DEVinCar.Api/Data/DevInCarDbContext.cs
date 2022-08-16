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
                .HasData( new[] {
                    new User (1, "jose@email.com", "12345678", "Jose", new DateTime(2000, 12, 10)),
                    new User (2, "andrea@email.com", "12345678", "Andrea", new DateTime(1999, 05, 11)),
                    new User (3, "adao@email.com", "12345678", "Adao", new DateTime(2005, 09, 02)),
                    new User (4, "monique@email.com", "12345678", "Monique", new DateTime(2001, 06, 07)),
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

        });
    }
}