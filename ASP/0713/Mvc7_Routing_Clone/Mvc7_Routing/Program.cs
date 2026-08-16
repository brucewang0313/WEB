using Mvc7_Routing_Clone.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//取得組態中資料庫連線設定
string connString = builder.Configuration.GetConnectionString("NorthwindContext");

//註冊EF Core的NorthwindContext
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connString));


string connectionString = builder.Configuration["DBConnection:CarContext_localdb"];

//註冊EF Core的CarContext
builder.Services.AddDbContext<CarContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//處理 ASP.NET Core 中的錯誤 - https://docs.microsoft.com/zh-tw/aspnet/core/fundamentals/error-handling?view=aspnetcore-6.0
//處理 ASP.NET Core web api 中的錯誤 - https://docs.microsoft.com/zh-tw/aspnet/core/web-api/handle-errors?view=aspnetcore-6.0

//app.UseStatusCodePagesWithRedirects("~/Errors/Error404/{0}");

//UseStatusCodePagesWithReExecute方必須用/開頭, 不能有~符號
app.UseStatusCodePagesWithReExecute("/Errors/ErrorPage", "?statuscode={0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//路由四個參數樣板
app.MapControllerRoute(
    name: "people",
    pattern: "people/{ssn}",
    constraints: new { ssn = "^\\d{3}-\\d{2}-\\d{4}$", },
    defaults: new { controller = "People", action = "List" });

app.MapControllerRoute(
    name: "MyCar",
    pattern: "/",
    defaults: new { controller = "Automobile", action = "Index" }
    );

//1.Car
app.MapControllerRoute(
    name: "MyCar",
    pattern: "Car",
    defaults: new { controller = "Automobile", action = "Index" }
    );


//2.Car/Brand/{brand}
app.MapControllerRoute(
    name: "FindCarByBrand",
    pattern: "Car/Brand/{brand?}",
    defaults: new { controller = "Automobile", action = "FindBrand" }
    );

//3.Car/Category/{cat}

//4.Car/Id/{id}

//5.Car/Year/{year}


//6.Car/Brand-Year/{brand}-{year}

//路由6可替換如下

//7.Car/TopSales/{topnumber}


//8.Car/Price/{min}-{max}


//9.Car/Pricing/{min}/{max}


//10.Car/PriceRange?min=50000&max=80000 - with QueryString


//11.Car/PriceCatchAll/Suv/Price/50000-80000?color=red&oil=gasoline查詢


//Search/keyword


//預設路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
