var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//將網銀服務註冊到DI Container
builder.Services.AddTransient<IBankService, FubonBankService>();
//builder.Services.AddTransient<IBankService, EsunBankService>();

//IZipcodeService
builder.Services.AddSingleton<IZipcodeService, TaiwanZipcodeService>();
//builder.Services.AddSingleton<IZipcodeService>(sp => new TaiwanZipcodeService());

//City縣市資料服務
builder.Services.AddSingleton<ICityService, TaiwanCityService>();

//IDeviceService
builder.Services.AddTransient<IDeviceService, ComputerService>();
//services.AddSingleton<IDeviceService, MobileService>();


//以擴充方法註冊一群服務, 實作在Extensions/MyConfigServiceCollectionExtensions.cs
/*
builder.Services.AddBankServiceGroup()
                .AddZipcodeServiceGroup()
                .AddCityServiceGroup()
                .AddDeviceServiceGroup();
*/


builder.Services.AddSingleton<MyHtmlHelper>();


//Options Pattern
builder.Services.Configure<DeviceOptions>(options => builder.Configuration.GetSection("MobileOptions").Bind(options));

builder.Services.Configure<FoodOptions>(options => builder.Configuration.GetSection("FoodOptions").Bind(options));


//Razor File Runtime Compilation
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}

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
