using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Infrastructure.EF.ReadModel
{
    public class PlanillaAsientoVueloReadModel
    {
        public Guid Id { get; set; }
        public string asiento { get; set; }
        public string estado { get; set; }
        public int activo { get; set; }
        public VueloReadModel vuelo { get; set; }
    }
}
