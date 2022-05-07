using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Infrastructure.EF;
using Aerolinea.Vuelos.Infrastructure.EF.Contexts;
using Aerolinea.Vuelos.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Infrastructure
{
    public static class Extensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString =  configuration.GetConnectionString("VueloDbConnectionString");

            services.AddDbContext<ReadDbContext>(context => context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context => context.UseSqlServer(connectionString));


            services.AddScoped<IVueloRepository, VueloRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
