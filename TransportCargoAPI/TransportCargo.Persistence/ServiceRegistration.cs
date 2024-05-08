using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCargo.Application.Interface.Contract;
using TransportCargo.Domain.Entities;
using TransportCargo.Persistence.Contexts;
using TransportCargo.Persistence.Repositories.Implementation;

namespace TransportCargo.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).EnableServiceProviderCaching(),
            ServiceLifetime.Transient);

            services.AddScoped<IInstruction, InstructionService>();
            services.AddScoped<ITransportContainer, TransportContainerService>();

        }
    }
}
