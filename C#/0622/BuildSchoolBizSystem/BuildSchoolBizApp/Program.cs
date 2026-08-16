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
        
        internal static BizContext CreateBizContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BizContext>();
            optionsBuilder.UseSqlServer(LoadConfiguration()
                .GetConnectionString("BsBizDBConnection"));
            return new BizContext(optionsBuilder.Options);
        }
        private static void InitialDB()
        {
            using(var context = CreateBizContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}