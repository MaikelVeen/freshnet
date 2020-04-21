using Freshnet.Data.Models;
using Freshnet.Data.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataServicesCollection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IDataService<DocumentModel>, DocumentModelService>();
            return services;
        }
    }
}