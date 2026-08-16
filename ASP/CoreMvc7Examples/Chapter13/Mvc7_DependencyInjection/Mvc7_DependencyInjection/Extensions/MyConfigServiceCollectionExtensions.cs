using Mvc7_DependencyInjection.Interfaces;
using Mvc7_DependencyInjection.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        /*
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {
            
            services.Configure<PositionOptions>(
                config.GetSection(PositionOptions.Position));
            services.Configure<ColorOptions>(
                config.GetSection(ColorOptions.Color));

            return services;
            
        }
        */

        public static IServiceCollection AddBankServiceGroup(this IServiceCollection services)
        {
            services.AddTransient<IBankService, FubonBankService>();
            services.AddTransient<IBankService, ESunBankService>();

            return services;
        }

        public static IServiceCollection AddDeviceServiceGroup(this IServiceCollection services)
        {
            services.AddScoped<IDeviceService, ComputerService>();
            services.AddScoped<IDeviceService, MobileService>();

            return services;
        }

        public static IServiceCollection AddZipcodeServiceGroup(this IServiceCollection services)
        {
            services.AddSingleton<IZipcodeService, TaiwanZipcodeService>();

            return services;
        }

        public static IServiceCollection AddCityServiceGroup(this IServiceCollection services)
        {
            services.AddSingleton<ICityService, TaiwanCityService>();

            return services;
        }
    }
}