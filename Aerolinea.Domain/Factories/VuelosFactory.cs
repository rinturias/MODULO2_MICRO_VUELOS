using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Domain.Factories
{
    public class VuelosFactory:IVuelosFactory
    {

        public Vuelo Create(DateTime horaSalida, DateTime horaLLegada, string estado, PrecioValue precio, DateTime fecha, Guid codDestino, Guid codOrigen, Guid codAeronave, int activo, CantidadValue StockAsientos)
        {
            return new Vuelo(horaSalida, horaLLegada, estado,precio, fecha, codDestino, codOrigen, codAeronave, activo,StockAsientos);
        }
    }
}
