using Services.Interfaces;
using Services.Repositories;

namespace Facturation_Application_Schad___Test.Properties
{
    public static class Services
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IFacturation, FacturationRepository>()
                .AddScoped<ItypeCustomer, TypeCustomerRepository>()
                .AddScoped<ICustomer, CustomerRepository>();

        }
    }
}
