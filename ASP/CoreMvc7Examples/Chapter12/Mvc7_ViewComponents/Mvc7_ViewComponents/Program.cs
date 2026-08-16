var builder = WebApplication.CreateBuilder(args);

//Add HttpClient Service into DI Container
builder.Services.AddHttpClient();


// Add services to the container.
builder.Services.AddControllersWithViews();


//取得組態中資料庫連線設定
string connectionString = builder.Configuration.GetConnectionString("DatabaseContext");

//註冊EF Core的DatabaseContext
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

//Seed Data植入資料至Database
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var logger = service.GetRequiredService<ILogger<Program>>();

    //方式一
    //try
    //{
    //    SeedData.Initialize(service);
    //    logger.LogError("植入種子資料至資料庫成功!");
    //}
    //catch (Exception ex)
    //{
    //    logger.LogError(ex, "植入種子資料至資料庫時發生錯誤.");
    //}

    //方式二
    try
    {
        var context = service.GetRequiredService<DatabaseContext>();
        SeedData.InitializeDB(context);
        logger.LogError("植入種子資料至資料庫成功!");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "植入種子資料至資料庫時發生錯誤.");
    }

}

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
