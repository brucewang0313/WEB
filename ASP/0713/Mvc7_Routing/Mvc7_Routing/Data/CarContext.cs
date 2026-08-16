
namespace Mvc7_Routing.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options):base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Fluent API - Fluent API in Entity Framework Core
            modelBuilder.Entity<Car>()
                .Property(p => p.Brand)
                .HasComment("汽車廠牌製造商");

            */

            modelBuilder.Entity<Car>().HasData(
                    new Car { Id = 1001, Brand = "Mercedes", Name = "AMG S63", Price = 145695, ImageUrl = "Mercedes_AMG_S63.jpg", Category = "轎車", Year = 2023, SoldNumber = 120 },
                    new Car { Id = 1002, Brand = "Audi", Name = "S8", Price = 116875, ImageUrl = "Audi_S8.jpg", Category = "轎車", Year = 2021, SoldNumber = 200 },
                    new Car { Id = 1003, Brand = "BMW", Name = "M3", Price = 66495, ImageUrl = "BMW_M3.jpg", Category = "轎車", Year = 2021, SoldNumber = 85 },
                    new Car { Id = 1004, Brand = "AlfaRomeo", Name = "Giulia Quadrifoglio", Price = 73595, ImageUrl = "AlfaRomeo_GiuliaQuadrifoglio.jpg", Category = "轎車", Year = 2022, SoldNumber = 62 },
                    new Car { Id = 1005, Brand = "Mercedes", Name = "GLS Class", Price = 68045, ImageUrl = "MercedesBenz_GLS.jpg", Category = "SUV", Year = 2019, SoldNumber = 250 },
                    new Car { Id = 1006, Brand = "Porsche", Name = "Cayenne", Price = 60650, ImageUrl = "Porsche_Cayenne.jpg", Category = "SUV", Year = 2023, SoldNumber = 160 },
                    new Car { Id = 1007, Brand = "Honda", Name = "CR-V", Price = 24985, ImageUrl = "Honda_CRV.jpg", Category = "SUV", Year = 2023, SoldNumber = 1200 },
                    new Car { Id = 1008, Brand = "Bugatti", Name = "Chiron", Price = 2998000, ImageUrl = "Bugatti_Chiron.jpg", Category = "跑車", Year = 2023, SoldNumber = 10 },
                    new Car { Id = 1009, Brand = "Lamborghini", Name = "Huracan", Price = 203295, ImageUrl = "Lamborghini_Huracan.jpg", Category = "跑車", Year = 2022, SoldNumber = 30 },
                    new Car { Id = 1010, Brand = "Porsche", Name = "718 Boxster", Price = 57050, ImageUrl = "Porsche_718Boxster.jpg", Category = "跑車", Year = 2019, SoldNumber = 49 }
                );
        }
    }
}
