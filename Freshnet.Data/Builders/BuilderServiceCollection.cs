using Freshnet.Data.Builders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BuilderServiceCollection
    {
        public static IServiceCollection AddBuilderServices(this IServiceCollection services)
        {
            services.AddScoped<IDocumentModelBuilder, DocumentModelBuilder>();
            return services;
        }
    }
}