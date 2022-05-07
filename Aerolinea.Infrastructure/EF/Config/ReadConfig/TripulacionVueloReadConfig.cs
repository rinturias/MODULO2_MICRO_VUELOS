using Aerolinea.Vuelos.Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Infrastructure.EF.Config.ReadConfig
{
    public class TripulacionVueloReadConfig : IEntityTypeConfiguration<TripulacionVueloReadModel>
    {
        public void Configure(EntityTypeBuilder<TripulacionVueloReadModel> builder)
        {
            builder.ToTable("TripulacionVuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.codTripulacion)
           .HasColumnName("codTripulacion");

            builder.Property(x => x.codEmpleado)
           .HasColumnName("codEmpleado");

            builder.Property(x => x.estado)
           .HasColumnName("estado")
           .HasMaxLength(1);

            builder.Property(x => x.activo)
           .HasColumnName("activo");


        }
    }
}
