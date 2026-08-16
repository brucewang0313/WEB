using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//取得組態中資料庫連線設定
string connectionString = builder.Configuration.GetConnectionString("AccountContext");

//註冊EF Core的CmsContext
builder.Services.AddDbContext<AccountContext>(options => options.UseSqlServer(connectionString));

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
            options.AccessDeniedPath = "/Account/Forbidden/";  //拒絕存取所導向的url
        });


//註冊加密方法
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
app.UseStaticFiles();

//Cookie Policy Middleware
app.UseCookiePolicy(new CookiePolicyOptions 
    { 
        MinimumSameSitePolicy = SameSiteMode.Strict
    });

app.UseRouting();

//Cookie驗證所需Middleware
app.UseAuthentication(); //驗證

app.UseAuthorization();  //授權

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
