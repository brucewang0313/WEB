using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Options Pattern
builder.Services.Configure<FoodOptions>(builder.Configuration);
//builder.Services.Configure<FoodOptions>(options => builder.Configuration.GetSection("FoodOptions").Bind(options));


//取得自訂組態檔目錄完整路徑
string path = Path.Combine(Directory.GetCurrentDirectory(), "ConfigFiles");

//加入自訂組態檔
var config = builder.Configuration;
config.AddJsonFile(Path.Combine(path, "FutureCorp.json"), optional: true, reloadOnChange: true);  //載入自訂JSON組態檔
config.AddIniFile(Path.Combine(path, "Mobile.ini"), true, true);      //載入自訂INI組態檔
config.AddXmlFile(Path.Combine(path, "Computer.xml"), true, true);    //載入自訂XML組態檔
config.AddJsonFile(Path.Combine(path, "Device.json"), true, true);   //載入自訂JSON組態檔
config.AddJsonFile(Path.Combine(path, "AICorp.json"), true, true);   //載入自訂JSON組態檔

string path2 = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
config.AddJsonFile(Path.Combine(path2, "Food.json"), true, true);

config.AddInMemoryCollection(new Dictionary<string, string>
{
        {"Asia:employees:1", "Mary"},
        {"Asia:employees:2", "John"},
        {"Asia:employees:3", "Kevin"},
        {"Asia:employees:4", "David"},
        {"Asia:employees:5", "Rose"}
});

//ComputerOptions + ComputerService相依性注入
builder.Services.Configure<DeviceOptions>(options => builder.Configuration.GetSection("ComputerOptions").Bind(options));
builder.Services.AddTransient<IDeviceService, ComputerService>();

//MoblieOptions + MobileService相依性注入
//builder.Services.Configure<DeviceOptions>(options => builder.Configuration.GetSection("MobileOptions").Bind(options));
//builder.Services.AddSingleton<IDeviceService, MobileService>();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
