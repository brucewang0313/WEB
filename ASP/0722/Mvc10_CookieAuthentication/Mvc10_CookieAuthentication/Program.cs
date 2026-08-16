using Microsoft.AspNetCore.Authentication.Cookies;
using Mvc10_CookieAuthentication.Interfaces;
using Mvc7_CookieAuthentication.Data;
using Mvc7_CookieAuthentication.Services;

namespace Mvc10_CookieAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //加入Cookie驗證
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //加入Cookie驗證, 同時設定選項
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        //預設登入驗證網址為Account/Login, 若想變更才需要設定LoginPath
                        //options.LoginPath = new PathString("/Account/Login/");
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                        options.SlidingExpiration = true;
                        options.AccessDeniedPath = "/Account/Forbidden/";
                    });

            //1.取得組態中資料庫連線設定
            string connectionString = builder.Configuration.GetConnectionString("AccountContext");

            //2.註冊EF Core的AccountContext
            builder.Services.AddDbContext<AccountContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddSingleton<IHashService, HashService>();

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

            app.UseAuthentication(); // 驗證(驗證帳密等等)

            app.UseAuthorization(); // 授權(限制角色讀取權限)

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
