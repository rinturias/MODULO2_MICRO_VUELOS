using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Infrastructure.EF.Config.WriteConfig
{
    public class PlanillaAsientoVueloWriteConfig : IEntityTypeConfiguration<PlanillaAsientoVuelo>
    {
        public void Configure(EntityTypeBuilder<PlanillaAsientoVuelo> builder)
        {
            builder.ToTable("PlanillaAsientoVuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.asiento)
           .HasColumnName("asiento")
           .HasMaxLength(20);



            builder.Property(x => x.estado)
           .HasColumnName("estado")
           .HasMaxLength(1);

            builder.Property(x => x.activo)
           .HasColumnName("activo");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
