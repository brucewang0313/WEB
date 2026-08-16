using BizDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BuildSchoolBizApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitialDB();
            Application.Run(new Form1());
        }

        private static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .Build();
        }

        /// <summary>
        /// 這個方法會建立並回傳 BizContext 的實例， 因為它會被同一個組件內的其他類別所使用，所以是 internal。
        /// </summary>
        /// <returns>Biz</returns>
        internal static BizContext CreateBizContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BizContext>();
            optionsBuilder.UseSqlServer(LoadConfiguration().GetConnectionString("BsBizDBConnection"));
            return new BizContext(optionsBuilder.Options);

            /* 或者使用以下寫法
             return new BizContext(new DbContextOptionsBuilder<BizContext>().UseSqlServer(LoadConfiguration().GetConnectionString("BizDatabase")).Options);
             */
        }

        private static void InitialDB()
        {
            using (var context = CreateBizContext())
            {
                if (!context.Database.CanConnect())
                {
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}