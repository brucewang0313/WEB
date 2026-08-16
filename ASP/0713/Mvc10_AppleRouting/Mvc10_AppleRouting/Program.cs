namespace Mvc10_AppleRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "Root",
                pattern: "/",
                defaults: new { controller = "Mac", action = "Index" }
                );

            app.MapControllerRoute(
                name: "MyMac",
                pattern: "ShowRoom/Mac",
                defaults: new { controller = "Mac", action = "Index" }
                );

            app.MapControllerRoute(
                name: "MyPad",
                pattern: "iPad",
                defaults: new { controller = "Pad", action = "Index" }
                );

            app.MapControllerRoute(
                name: "MyPhone",
                pattern: "iPhone",
                defaults: new { controller = "Phone", action = "Index" }
                );

            app.MapControllerRoute(
                name: "MyWatch",
                pattern: "Watch",
                defaults: new { controller = "Watch", action = "Index" }
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
