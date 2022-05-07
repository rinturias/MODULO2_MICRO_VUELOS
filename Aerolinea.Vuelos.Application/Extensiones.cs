using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

using Aerolinea.Vuelos.Application.Services;
using Aerolinea.Vuelos.Domain.Factories;
using MediatR;

namespace Aerolinea.Vuelos.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IVueloServices, VueloServices>();
            services.AddTransient<IVuelosFactory, VuelosFactory>();



            return services;
        }

    }
}
