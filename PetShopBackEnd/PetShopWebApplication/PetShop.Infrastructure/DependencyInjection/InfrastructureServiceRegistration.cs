using Microsoft.Extensions.DependencyInjection;
using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Infrastructure.Repositories;
using PetShop.Infrastructure.Services;
using PetShop.Infrastructure.Services.Logging;
using PetShop.Infrastructure.Services.Sales;

namespace PetShop.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IHealthRecordService, HealthRecordService>();
            services.AddScoped<ISellPetService,SellPetService>();

            services.AddScoped<DaySalesService>();
            services.AddScoped<NightSalesService>();
            services.AddScoped<SalesSelectorService>();
            

            // Logger 
            services.AddSingleton<ILoggerService, FileLoggerService>();

            return services;
        }
    }
}
