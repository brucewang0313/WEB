using Core7_WebApiServices.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUtility, Utility>();

string CorsPolicyName = "_CorsPolicy";

builder.Services.AddCors(options =>
{
    //1.開放所有Origins存取
    options.AddPolicy(name: CorsPolicyName,
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    
    //2.限制特定Origins存取
    /*
    options.AddPolicy(name: CorsPolicyName,
        builder =>
        {
            builder.WithOrigins("https://localhost:7400", "http://localhost:6500", "https://www.Shopping.com.tw")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    */

    //options.AddDefaultPolicy(
    //    builder =>
    //    {
    //        builder.AllowAnyOrigin()
    //               .AllowAnyMethod()
    //               .AllowAnyHeader();

    //        //builder.WithOrigins("https://www.codemagic.com.tw");
    //    });
});

builder.Services.AddTransient<IUtility, Utility>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
