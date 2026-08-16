using JwtCourseApi.Basic.Options;
using JwtExercise.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtExercise.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>() ?? throw new InvalidOperationException("The Jwt configuration section is missing.");

                 options.MapInboundClaims = false;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidIssuer = jwtOptions.Issuer,

                     ValidateAudience = true,
                     ValidAudience = jwtOptions.Audience,

                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero,

                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),

                     NameClaimType = "name",
                     RoleClaimType = "role"
                 };
             });

            builder.Services.AddSingleton<IDemoUserService, DemoUserService>();
            builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
