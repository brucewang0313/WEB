using Mvc7_QuestionaryModelBinding.Data;
using Mvc7_QuestionaryModelBinding.Helpers;
using Mvc7_QuestionaryModelBinding.Models;
using Mvc7_QuestionaryModelBinding.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//取得組態中資料庫連線設定
//string? connectionString = builder.Configuration.GetConnectionString("NorthwindContext");
//string? connQuestionary = builder.Configuration.GetConnectionString("QuestionaryContext");

string connectionString = null;

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("NorthwindContext");
}

string connQuestionary = null;
if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
{
    connectionString = builder.Configuration.GetConnectionString("QuestionaryContext");
}


//在DI Container註冊EF Core的DbContext
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<QuestionaryContext>(options => options.UseSqlServer(connQuestionary));

builder.Services.AddScoped<TransformService>();

builder.Services.AddScoped<TransformModelService>();

builder.Services.AddScoped<QuestionaryService>();
builder.Services.AddScoped<QuestionaryRepository>();

builder.Services.AddSingleton<FileLoader>();

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
