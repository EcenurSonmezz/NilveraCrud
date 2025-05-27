using Microsoft.Extensions.DependencyInjection;
using Nilvera.Infrastructure.Repositories;
using Nilvera.Persistence.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Nilvera.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
            services.AddScoped<IFirmaRepository, FirmaRepository>();
        }
    }
}
