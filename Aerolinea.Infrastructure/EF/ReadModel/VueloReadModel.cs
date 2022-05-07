using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Infrastructure.EF.ReadModel
{
    public class VueloReadModel
    {
        public Guid Id { get; set; }
        // public long codVuelo { get; private set; }
        public DateTime horaSalida { get; set; }
        public DateTime horaLLegada { get; set; }
        public string estado { get;  set; }
        public decimal precio { get;  set; }
        public DateTime fecha { get;  set; }
        public Guid codDestino { get;  set; }
        public Guid codOrigen { get;  set; }
        public Guid codAeronave { get;  set; }
        public int activo { get;  set; }
        public int stockAsientos { get; set; }
        public ICollection<TripulacionVueloReadModel> DetalleTripulacion { get; set; }

        public ICollection<PlanillaAsientoVueloReadModel> DetallePlanillaVuelo { get; set; }

    }
}
