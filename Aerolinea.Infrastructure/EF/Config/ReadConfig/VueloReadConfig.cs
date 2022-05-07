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
    public class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel>
       
    {
        public void Configure(EntityTypeBuilder<VueloReadModel> builder)
        {
            builder.ToTable("Vuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.horaSalida)
             .HasColumnName("horaSalida")
             .HasColumnType("DateTime");


            builder.Property(x => x.horaLLegada)
            .HasColumnName("horaLLegada")
            .HasColumnType("DateTime");



         builder.Property(x => x.estado)
                  .HasColumnName("estado")
                  .HasMaxLength(1);


         builder.Property(x => x.precio)
           .HasColumnName("precio")
           .HasColumnType("decimal")
           .HasPrecision(12, 2);

        builder.Property(x => x.fecha)
          .HasColumnName("fecha")
          .HasColumnType("DateTime");


         builder.Property(x => x.codDestino)
              .HasColumnName("codDestino");

         builder.Property(x => x.codOrigen)
            .HasColumnName("codOrigen");

         builder.Property(x => x.codAeronave)
        .HasColumnName("codAeronave");

            builder.Property(x => x.activo)
          .HasColumnName("activo");

            builder.Property(x => x.stockAsientos)
      .HasColumnName("stockAsientos");


            builder.HasMany(x => x.DetalleTripulacion)
              .WithOne(x => x.vuelo);


            // builder.HasMany(x => x.detallePlanillaVuelo)
            //.WithOne(x => x.vuelo);

        }
 



      
    }
}
