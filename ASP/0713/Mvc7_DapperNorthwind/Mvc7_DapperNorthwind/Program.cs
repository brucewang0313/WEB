using Microsoft.EntityFrameworkCore;
using Mvc7_DapperNorthwind.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//取得組態中資料庫連線設定
string? connectionString = builder.Configuration.GetConnectionString("NorthwindContext");

//註冊EF Core的NorthwindContext
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));

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

//app.MapGet("/", ()=> "Hello World!");


//如果希望預設執行的首頁是Products/Index的頁面
app.MapGet("/", context =>
{
    context.Response.Redirect("/Products/Index");

    return Task.CompletedTask;
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
