using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Application.Dto
{
    public class PlanillaAsientosVueloDto
    {

        public Guid codPlanillaAsiento { get; set; }
        public string asiento { get;  set; }
        public string estado { get;  set; }
       
    }
}
