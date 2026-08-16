using EntitySample001.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace EntitySample001
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
            LoadConfiguration();
            InitialDB();
            Application.Run(new Form1());
        }

        public static IConfiguration? Configuration { get; private set; }
        static void LoadConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public static void InitialDB()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactContext>();
            optionsBuilder.UseSqlServer(Configuration?.GetConnectionString("DefaultConnection"));

            using (var context = new ContactContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }
        }
    }
}