using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Infrastructure.EF.Config.ReadConfig;
using Aerolinea.Vuelos.Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Infrastructure.EF.Contexts
{
    public class ReadDbContext: DbContext
    {
        public virtual DbSet<VueloReadModel> Vuelo { set; get; }
        public virtual DbSet<TripulacionVueloReadModel> TripulacionVuelo { set; get; }
        public virtual DbSet<PlanillaAsientoVueloReadModel> PlanillaAsientoVuelo { set; get; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var vueloConfig = new VueloReadConfig();
            var tripulacionVueloConfig = new TripulacionVueloReadConfig();
            var planillaAsientosConfig = new PlanillaAsientoVueloReadConfig();

            modelBuilder.ApplyConfiguration<VueloReadModel>(vueloConfig);
            modelBuilder.ApplyConfiguration<TripulacionVueloReadModel>(tripulacionVueloConfig);
            modelBuilder.ApplyConfiguration<PlanillaAsientoVueloReadModel>(planillaAsientosConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<VueloHabilitado>();
            //modelBuilder.Ignore<ItemPedidoAgregado>();
        }

    }
}
