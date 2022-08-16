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
    public Dbset<City> Cities { get; set; }

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
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("Cities");
            entity.HasKey(a => a.Id);
            entity
                    .Property(a => a.StateId)
                    .IsRequired();
            entity
                    .Property(a => a.Name)
                    .HasMaxLenght(255)
                    .IsRequired();

        });
    }
}