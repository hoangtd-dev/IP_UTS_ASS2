using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RentalCar.Entities;
using RentalCar.Entities.DefaultData;

namespace RentalCar.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarReservation> CarReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CarTypeEntityConfiguration(modelBuilder);
            CarBrandEntityConfiguration(modelBuilder);
            CarEntityConfiguration(modelBuilder);
            CarReservationEntityConfiguration(modelBuilder);

            DefaultRentalCarData.SetupDefaultData(modelBuilder);
        }

        private void CarReservationEntityConfiguration(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<CarReservation>(entity => {
                entity.Property(p => p.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.DriverLicense)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.StartDate)
                    .IsRequired();

                entity.Property(p => p.RentalPeriod)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.HasOne(p => p.Car)
                    .WithMany(p => p.CarReservations)
                    .HasForeignKey(p => p.CarId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void CarTypeEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarType>(entity => {
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }

        private void CarBrandEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>(entity => {
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }

        private void CarEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity => {
                entity.HasKey(p => p.VIN);

                entity.Property(p => p.VIN)
                    .IsRequired()
                    .HasMaxLength(17)
                    .HasValueGenerator<ShortGuidValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.ImageUrl)
                    .IsRequired();

                entity.Property(p => p.PricePerDay)
                    .IsRequired()
                    .HasPrecision(18, 2);

                entity.Property(p => p.YearOfManufacture)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(p => p.Mileage)
                   .IsRequired()
                    .HasPrecision(18, 2);

                entity.Property(p => p.FuelType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(p => p.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(p => p.IsAvailable)
                    .IsRequired();

                entity.Property(p => p.CarModel)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(p => p.CarBrand)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(p => p.CarBrandId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.CarType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(p => p.CarTypeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public class ShortGuidValueGenerator : ValueGenerator<string>
        {
            public override bool GeneratesTemporaryValues => false;

            public override string Next(EntityEntry entry)
            {
                return Guid.NewGuid().ToString("N").Substring(0, 17).ToUpper();
            }
        }
    }
}
