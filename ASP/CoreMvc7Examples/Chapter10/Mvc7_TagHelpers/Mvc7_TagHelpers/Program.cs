using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mvc7_TagHelpers.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//取得組態中資料庫連線設定
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//註冊EF Core的ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

//註冊EF Core的DatabaseContext
builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddTransient<ICityService, TaiwanCityService>();

builder.Services.AddDistributedMemoryCache();

//Razor File Runtime Compilation
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//Area註冊必須在default路由前面
//註冊Area路由方式一 : 以下設定總括對所有Area路由有效, 只需設定一個就夠了
app.MapControllerRoute(
        name: "AreaRouting",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

//有上面就夠了, 下面其實不用, 僅列出
//app.MapControllerRoute(
//        name: "MenClothing",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );

//app.MapControllerRoute(
//        name: "WomenClothing",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );

//註冊Area路由方式二
//app.MapAreaControllerRoute(
//        name: "MyBlogs",
//        areaName: "Blogs",
//        pattern: "BlogArea/{controller=Blog}/{action=Index}/{id?}"
//    );

//app.MapAreaControllerRoute(
//        name: "MenClothing",
//        areaName: "Men",
//        pattern: "MenArea/{controller=Home}/{action=Index}/{id?}"
//    );

//app.MapAreaControllerRoute(
//        name: "WomenClothing",
//        areaName: "Women",
//        pattern: "WomenArea/{controller=Home}/{action=Index}/{id?}"
//    );

//註冊Area路由方式三
//app.MapAreaControllerRoute(
//        name: "MyBlogs",
//        areaName: "Blogs",
//        pattern: "{area:exists}/{controller=Blog}/{action=Index}/{id?}"
//    );

//app.MapAreaControllerRoute(
//        name: "MenClothing",
//        areaName: "Men",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );

//app.MapAreaControllerRoute(
//        name: "WomenClothing",
//        areaName: "Women",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );

app.MapControllerRoute(
        name: "UserInfo",
        pattern: "UserInfo",
        defaults: new { controller = "Person", action = "UserInformation" }
        );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
