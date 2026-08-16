using Microsoft.Extensions.DependencyInjection;

namespace Mvc7_ViewComponents.Models
{
    public class SeedData
    {
        //方式一
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context=new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                //context.Database.Migrate();
                //or

                context.Database.EnsureCreated();

                if (context.SalesReport.Any() || context.Products.Any())
                {
                    return; //Seed Data has been seeded
                }

                context.SalesReport.AddRange(
                    new Sales { ProductId = "A0153", Name = "筆記型電腦", Price=19900, SalesVolume=2000 },
                    new Sales { ProductId = "B2564", Name = "LCD螢幕", Price = 5200, SalesVolume = 4500 },
                    new Sales { ProductId = "C3842", Name = "鍵盤", Price = 399, SalesVolume = 3000 },
                    new Sales { ProductId = "D1569", Name = "滑鼠", Price = 199, SalesVolume = 5000 },
                    new Sales { ProductId = "E9528", Name = "SSD硬碟", Price = 2890, SalesVolume = 5500 },
                    new Sales { ProductId = "F7302", Name = "HDD硬碟", Price = 2500, SalesVolume = 2500 },
                    new Sales { ProductId = "G5566", Name = "CPU處理器", Price = 7600, SalesVolume = 3950 },
                    new Sales { ProductId = "H3399", Name = "DRAM記憶體", Price = 1500, SalesVolume = 6000 },
                    new Sales { ProductId = "I6813", Name = "顯示卡", Price = 3990, SalesVolume = 4000 },
                    new Sales { ProductId = "J8172", Name = "PC桌上型電腦", Price = 2500, SalesVolume = 3500 }
                    );

                context.SaveChanges();

                context.Products.AddRange(
                    new Product { ProductId = "A0153", Name = "筆記型電腦", Price = 19900, Category="筆電" },
                    new Product { ProductId = "B2564", Name = "LCD螢幕", Price = 5200, Category = "螢幕" },
                    new Product { ProductId = "C3842", Name = "鍵盤", Price = 399, Category = "電腦週邊" },
                    new Product { ProductId = "D1569", Name = "滑鼠", Price = 199, Category = "電腦週邊" },
                    new Product { ProductId = "E9528", Name = "SSD硬碟", Price = 2890, Category = "儲存設備" },
                    new Product { ProductId = "F7302", Name = "HDD硬碟", Price = 2500, Category = "儲存設備" },
                    new Product { ProductId = "G5566", Name = "CPU處理器", Price = 7600, Category = "電腦週邊" },
                    new Product { ProductId = "H3399", Name = "DRAM記憶體", Price = 1500, Category = "記憶體" },
                    new Product { ProductId = "I6813", Name = "顯示卡", Price = 3990, Category = "電腦週邊" },
                    new Product { ProductId = "J8172", Name = "PC桌上型電腦", Price = 2500, Category = "桌機" }
                    );

                context.SaveChanges();
                    
            }
        }

        //方式二
        public static void InitializeDB(DatabaseContext context)
        {
            //context.Database.Migrate();
            //or

            context.Database.EnsureCreated();

            if (context.SalesReport.Any() || context.Products.Any())
            {
                return; //Seed Data has been seeded
            }

            context.SalesReport.AddRange(
                new Sales { ProductId = "A0153", Name = "筆記型電腦", Price=19900, SalesVolume=2000 },
                new Sales { ProductId = "B2564", Name = "LCD螢幕", Price = 5200, SalesVolume = 4500 },
                new Sales { ProductId = "C3842", Name = "鍵盤", Price = 399, SalesVolume = 3000 },
                new Sales { ProductId = "D1569", Name = "滑鼠", Price = 199, SalesVolume = 5000 },
                new Sales { ProductId = "E9528", Name = "SSD硬碟", Price = 2890, SalesVolume = 5500 },
                new Sales { ProductId = "F7302", Name = "HDD硬碟", Price = 2500, SalesVolume = 2500 },
                new Sales { ProductId = "G5566", Name = "CPU處理器", Price = 7600, SalesVolume = 3950 },
                new Sales { ProductId = "H3399", Name = "DRAM記憶體", Price = 1500, SalesVolume = 6000 },
                new Sales { ProductId = "I6813", Name = "顯示卡", Price = 3990, SalesVolume = 4000 },
                new Sales { ProductId = "J8172", Name = "PC桌上型電腦", Price = 2500, SalesVolume = 3500 }
                );

            context.SaveChanges();

            context.Products.AddRange(
                new Product { ProductId = "A0153", Name = "筆記型電腦", Price = 19900, Category="筆電" },
                new Product { ProductId = "B2564", Name = "LCD螢幕", Price = 5200, Category = "螢幕" },
                new Product { ProductId = "C3842", Name = "鍵盤", Price = 399, Category = "電腦週邊" },
                new Product { ProductId = "D1569", Name = "滑鼠", Price = 199, Category = "電腦週邊" },
                new Product { ProductId = "E9528", Name = "SSD硬碟", Price = 2890, Category = "儲存設備" },
                new Product { ProductId = "F7302", Name = "HDD硬碟", Price = 2500, Category = "儲存設備" },
                new Product { ProductId = "G5566", Name = "CPU處理器", Price = 7600, Category = "電腦週邊" },
                new Product { ProductId = "H3399", Name = "DRAM記憶體", Price = 1500, Category = "記憶體" },
                new Product { ProductId = "I6813", Name = "顯示卡", Price = 3990, Category = "電腦週邊" },
                new Product { ProductId = "J8172", Name = "PC桌上型電腦", Price = 2500, Category = "桌機" }
                );

            context.SaveChanges();
        }
    }
}
