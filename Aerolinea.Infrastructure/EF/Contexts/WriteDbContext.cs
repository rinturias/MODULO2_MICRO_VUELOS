using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Infrastructure.EF.Config.WriteConfig;
using Microsoft.EntityFrameworkCore;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Infrastructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Vuelo> vuelo { get; set; }
        public virtual DbSet<TripulacionVuelo> tripulacionVuelo { get; set; }

        public virtual DbSet<PlanillaAsientoVuelo> planillaAsientoVuelo { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var vueloConfig = new VueloWriteConfig();
            var tripulacionVueloConfig = new TripulacionVueloWriteConfig();
            var planillaAsientosConfig = new PlanillaAsientoVueloWriteConfig();

            modelBuilder.ApplyConfiguration<Vuelo>(vueloConfig);
           modelBuilder.ApplyConfiguration<TripulacionVuelo>(tripulacionVueloConfig);
           modelBuilder.ApplyConfiguration<PlanillaAsientoVuelo>(planillaAsientosConfig);



            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<VueloHabilitado>();
          //  modelBuilder.Ignore<ItemPedidoAgregado>();
        }
    }
}