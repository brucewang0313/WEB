using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging.AzureAppServices;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
//WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//自訂ContenRoot & WebRoot

/*變更EnvironmentName, ContentRootPath, WebRootPath
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ApplicationName = typeof(Program).Assembly.FullName,
    EnvironmentName = Environments.Staging,
    ContentRootPath = Directory.GetCurrentDirectory(),
    WebRootPath = Path.Combine(Directory.GetCurrentDirectory(),"StaticFilesLibrary")
});

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContenRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRoot Path: {builder.Environment.WebRootPath}");
*/


//設定目錄路徑, .NET 6/.NET 7不支援以下語法變更
//builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
//builder.WebHost.UseWebRoot(Directory.GetCurrentDirectory());


//加入Configuration組態設定
builder.Configuration.AddJsonFile("hostsettings.json", optional:true);
builder.Configuration.AddEnvironmentVariables(prefix: "PREFIX_");
builder.Configuration.AddCommandLine(args);

//設定組態檔完整路徑
string path = Path.Combine(Directory.GetCurrentDirectory(), "ConfigFiles");

//加入自訂組態檔
var config = builder.Configuration;
config.AddJsonFile(Path.Combine(path, "FutureCorp.json"), optional: true, reloadOnChange: true);  //載入自訂JSON組態檔
config.AddIniFile(Path.Combine(path, "Mobile.ini"), true, true);      //載入自訂INI組態檔
config.AddXmlFile(Path.Combine(path, "Computer.xml"), true, true);    //載入自訂XML組態檔
config.AddJsonFile(Path.Combine(path, "Device.json"), true, true);   //載入自訂JSON組態檔

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

//Add Logging Provider
var logging = builder.Logging;
logging.ClearProviders();
logging.AddConsole();
logging.AddDebug();
logging.AddEventSourceLogger();
logging.AddEventLog();  //for windows only
logging.AddTraceSource(new System.Diagnostics.SourceSwitch("loggingSwitch", "Verbose"), new TextWriterTraceListener("LoggingService.txt"));
logging.AddAzureWebAppDiagnostics();
logging.AddApplicationInsights();


// Add services to the container.
builder.Services.AddControllersWithViews();

//取得組態中資料庫連線設定
string connectionString = builder.Configuration.GetConnectionString("DatabaseContext");

//註冊EF Core的DatabaseContext
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

//在DI Container中註冊DeveloperOptions類別
builder.Services.Configure<DeveloperOptions>(options => builder.Configuration.GetSection("Developer").Bind(options));

var app = builder.Build();

//HTTP logging middleware - https://learn.microsoft.com/zh-tw/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-6.0#http-logging-middleware
//app.UseHttpLogging();   //記錄HTTP要求和回應


//app.UseW3CLogging();    //以W3C擴充記錄檔格式產生伺服器存取記錄

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); //一般例外頁
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();  //HTTP Strict Transport Security Protocol
}

app.UseHttpsRedirection();  //將HTTP轉向HTTPS

app.UseStaticFiles();   //啟用靜態檔服務

/*
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFilesLibrary"))
});
*/

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFilesLibrary")),
    RequestPath = "/StaticFiles"
});

//app.UseCookiePolicy();  //使用Cookie Policy


app.UseRouting();   //使用路由

//app.UseRequestLocalization();   //根據用戶端提供的資訊自動設定要求的文化特性資訊
//app.UseCors();  //使用CORS

//app.UseAuthentication();    //驗證

app.UseAuthorization(); //授權

//app.UseSession();   //使用 Session
//app.UseResponseCompression();   //回應壓縮
//app.UseResponseCaching();   //回應快取

//端點路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
