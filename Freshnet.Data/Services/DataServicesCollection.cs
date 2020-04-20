using Freshnet.Data.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataServicesCollection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IDocumentModelService, DocumentModelService>();
            return services;
        }
    }
}