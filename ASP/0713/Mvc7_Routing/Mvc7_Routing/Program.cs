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
    name: "FindCarByYear",
    pattern: "Car/Year/{year=2023}",
    constraints: new { year = @"^\d{4}$" },
    defaults: new { controller = "Automobile", action = "FindYear" }
    );

//如果希望預設執行的首頁是Products/Index的頁面
//app.MapGet("/", context =>
//{
//    context.Response.Redirect("/Products/Index");

//    return Task.CompletedTask;
//});

//app.MapControllerRoute(
//    name: "RootCar",
//    pattern: "/",
//    defaults: new { controller = "Automobile", action = "Index" }
//    );

//1.Car
app.MapControllerRoute(
    name : "MyCar",
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
app.MapControllerRoute(
    name: "CarCategory",
    pattern: "Car/Category/{cat?}",
    defaults: new { controller = "Automobile", action = "FindCategory" }
    );

//4.Car/Id/{id}
app.MapControllerRoute(
    name: "FindCarById",
    pattern: "Car/Id/{id?}",
    defaults: new { controller = "Automobile", action = "FindId" }
    );

//5.Car/Year/{year}
app.MapControllerRoute(
    name: "FindCarByYear",
    pattern: "Car/Year/{year=2023}",
    constraints: new { year = @"^\d{4}$" },
    defaults: new { controller = "Automobile", action = "FindYear" }
    );

//6.Car/Brand-Year/{brand}-{year}
app.MapControllerRoute(
    name: "FindCarByBrandYear",
    pattern: "Car/Brand-Year/{brand=BMW}-{year=2021}",
    constraints: new { brand = @"^\w+$", year = @"^\d{4}$" },
    defaults: new { controller = "Automobile", action = "FindBrandYear" }
    );

//路由6可替換如下
app.MapControllerRoute(
    name: "FindCarByBrandYear2",
    pattern: "Car/BrandYear/{brand}={year}",
    constraints: new { brand = @"^\[A-Za-z]+$", year = @"^\d{4}$" },
    defaults: new { controller = "Automobile", action = "FindBrandYear" }
    );

//7.Car/TopSales/{topnumber}
app.MapControllerRoute(
    name: "CarTopSales",
    pattern: "Car/TopSales/{topnumber=5}",
    constraints: new { topnumber = @"^[1-9]+[0-9]*$" },
    defaults: new { controller = "Automobile", action = "TopSales" }
    );

//8.Car/Price/{min}-{max}
app.MapControllerRoute(
    name: "CarPrice",
    pattern: "Car/Price/{min}-{max}",
    constraints: new { min = @"^[1-9]+[0-9]*$", max = @"^[1-9]+[0-9]*$" },
    defaults: new { controller = "Automobile", action = "Price" }
    );

//9.Car/Pricing/{min}/{max}
app.MapControllerRoute(
    name: "CarPricing",
    pattern: "Car/Pricing/{min}/{max}",
    constraints: new { min = @"^[1-9]+[0-9]*$", max = @"^[1-9]+[0-9]*$" },
    defaults: new { controller = "Automobile", action = "Pricing" }
    );

//10.Car/PriceRange?min=50000&max=80000 - with QueryString
app.MapControllerRoute(
    name: "CarPriceRange",
    pattern: "Car/PriceRange",
    defaults: new { controller = "Automobile", action = "PriceRange" }
    );

//飯店路由結合QueryString
//Url : Room/9527?city=Taipei&adults=1&children=2&check_in=2025-04-10&check_out=2025-04-17
app.MapControllerRoute(
    name: "HotelRoom",
    pattern: "Room/{roomid}",
    defaults: new { controller = "Hotels", action = "FindRoom" }
    );


//11.Car/PriceCatchAll/Suv/Price/50000-80000?color=red&oil=gasoline查詢
app.MapControllerRoute(
    name: "PriceCatchAll",
    pattern: "Car/PriceCatchAll/{**catchall}",
    defaults: new { controller = "Automobile", action = "PriceCatchAll" }
    );

//Search/keyword
app.MapControllerRoute(
    name: "SearchKeyword",
    pattern: "Search/{keyword?}",
    defaults: new { controller = "Site", action = "SearchKeyword" }
    );

//預設路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
